import { Injectable } from '@angular/core';
import { Observable, tap } from 'rxjs';
import { IStudent } from '../shared/models/student';
import { DataService } from '../shared/services/data.service';
import { StorageService } from '../shared/services/storage.service';

@Injectable()
export class StudentService {
  private baseUrl = 'https://localhost:5000/api/';
  constructor(private _service: DataService, private _storage: StorageService) { }

  getStudent(id: number): Observable<IStudent> {
    let url = this.baseUrl + `students/${id}`;

    return this._service.get(url).pipe<IStudent>(tap((response: any) => {
      return response;
    }))
  }

  getStudents(): Observable<IStudent[]> {
    let url = this.baseUrl + 'students';

    return this._service.get(url).pipe<IStudent[]>(tap((response: any) => {
      return response;
    }))
  }
}
