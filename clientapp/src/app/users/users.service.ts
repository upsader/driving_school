import { Injectable } from '@angular/core';
import { Observable, tap } from 'rxjs';
import { IUser } from '../shared/models/user';
import { DataService } from '../shared/services/data.service';
import { StorageService } from '../shared/services/storage.service';

@Injectable()
export class UsersService {
  private baseUrl = 'https://localhost:5000/api/';
  constructor(private _service: DataService, private _storage: StorageService) { }

  getUsers(): Observable<IUser[]> {
    let url = this.baseUrl + 'users';

    return this._service.get(url).pipe<IUser[]>(tap((response: any) => {
      return response;
    }))
  }

  createUser(data: any): Observable<IUser[]> {
    let url = this.baseUrl + 'users/create';
    
    return this._service.post(url, data, null, true).pipe<IUser[]>(tap((response: any) => {
      return response;
    }))
  }

  deleteUser(email: string): Observable<Response> {
    let url = this.baseUrl + 'users/delete';
    
    return this._service.delete(url, email, null, true).pipe(tap((response: any) => {
      console.log(response);
      return response;
    }));
  }
}
