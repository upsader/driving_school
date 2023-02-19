import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import { StorageService } from './storage.service';
import { Subject } from 'rxjs';
import { ToastrService } from 'ngx-toastr';
import { BusyService } from './busy.service';
import jwt_decode from "jwt-decode";
import { IUser } from '../models/user';


@Injectable({
    providedIn: 'root'
})
export class AuthenticationService {
    private baseUrl = 'https://localhost:5000/';
    private authenticationSource = new Subject<IUser | null>();
    authenticationChallenge$ = this.authenticationSource.asObservable();

    constructor(
        private _http: HttpClient,
        private _router: Router,
        private _storage: StorageService,
        private _toastr: ToastrService,
        private _busy: BusyService
    ) { }

    public authUserWithCredentials(body: any) {
        this._busy.busy();
        const headers = this.setHeaders();
        setTimeout(() => {
            return this._http.post<IUser>(this.baseUrl + 'api/user/login', body, { headers })
                .subscribe({
                    next: (response: IUser) => {
                        console.log(response);
                        this.authenticationSource.next(response);
                        this._storage.store('user', response);
                        this._storage.store('token', response.token)
                        this._router.navigate(['/dashboard']);
                    },
                    error: (error: HttpErrorResponse) => {
                        this.HandleError(error);
                        this._busy.idle()
                    },
                    complete: () => this._busy.idle()
                })
        }, 1000);
    }

    public isTokenExpired(token: string): boolean {
        const decoded: any = jwt_decode(token);
        const currentTime = new Date().getTime() / 1000;
        return decoded["exp"] < currentTime;
    }

    public logout(): void {
        this.authenticationSource.next(null);
        this._storage.store('user', '');
        this._storage.store('token', '');
        this._router.navigate(['/login']);
    }

    public isLoggedIn(): boolean {
        const token = this.getToken();

        if (token !== undefined) {
            if (!this.isTokenExpired(token)){
                const user: IUser = this._storage.retrieve('user');
                this.authenticationSource.next(user);
                return true;
            }
        }
        this._storage.store('user', '');
        this._storage.store('token', '');
        return false;
    }

    public HandleError(error: HttpErrorResponse): void {
        console.log(error);
        this.authenticationSource.next(null);
        this._toastr.error(error.message, error.statusText);
    }

    public HandleAuthError(message: string): void {
        this.authenticationSource.next(null);
        this._toastr.error(message, '401 Authentication Error');
    }

    public getToken(): any {
        return this._storage.retrieve('token');
    }

    private setHeaders(): HttpHeaders {
        let headers = new HttpHeaders()

        headers.set('Content-Type', 'application/json');
        headers.set('Accept', 'application/json');
        headers.set('Access-Control-Allow-Origin', '*');

        const token = this.getToken();

        if (token !== '') {
            headers.set('Authorization', `Bearer ${token}`);
        }

        return headers;
    }
}
