import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, finalize, Observable, throwError } from 'rxjs';
import { BusyService } from './busy.service';
import { StorageService } from './storage.service';
@Injectable({
    providedIn: 'root'
})
export class DataService {
    constructor(
        private _http: HttpClient, 
        private _storage: StorageService, 
        private _busy: BusyService, 
        ) { }

    get(url: string, params?: any, loading: boolean = false): Observable<Response> {
        if (loading) this._busy.busy();
        let options = {};
        this.setHeaders(options);

        return this._http.get<Response>(url, options)
            .pipe(
                catchError(this.handleError),
                finalize(() => loading ? this._busy.idle() : '')
            );
    }

    postWithId(url: string, data: any, params?: any): Observable<Response> {
        return this.doPost(url, data, params);
    }

    post(url: string, data: any, params?: any, loading: boolean = false): Observable<Response> {
        return this.doPost(url, data, params, loading);
    }

    public doPost(url: string, data: any, params?: any, loading: boolean = false): Observable<Response> {
        if (loading) this._busy.busy();
        let options = {};
        this.setHeaders(options);

        return this._http.post<Response>(url, data, options)
            .pipe(
                catchError(this.handleError),
                finalize(() => loading ? this._busy.idle() : '')
            );
    }

    public handleError(error: any) {
        if (error.error != null) {
            if (error.error instanceof ErrorEvent) {
                // A client-side or network error occurred. Handle it accordingly.
                console.error('Client side network error occurred:', error.error.message);
            }
        } else {
            // The backend returned an unsuccessful response code.
            // The response body may contain clues as to what went wrong,
            console.error('Backend - ' +
                `status: ${error.status}, ` +
                `statusText: ${error.statusText}, ` +
                `message: ${error.message}`);
        }
        // return an observable with a user-facing error message
        return throwError(error || 'server error');
    }

    public setHeaders(options: any) {
        options["headers"] = new HttpHeaders().append('Access-Control-Allow-Origin', '*')
            .append('Content-Type', 'application/json')
            .append('Accept', 'application/json')
            .append('Authorization', `Bearer ${this._storage.retrieve('token')}`);
    }
}