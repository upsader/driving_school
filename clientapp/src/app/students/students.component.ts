import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { IStudent } from '../shared/models/student';
import { StudentService } from './students.service';

@Component({
  selector: 'app-students',
  templateUrl: './students.component.html',
  styleUrls: ['./students.component.scss']
})
export class StudentsComponent implements OnInit {

  public displayedColumns: string[] = ['firstName', 'lastName', 'email', 'phone', 'age', 'registrationDate', 'address', 'trainingCategory', 'mark', 'examType'];
  public students: MatTableDataSource<IStudent> = new MatTableDataSource<IStudent>();

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(private _service: StudentService) { }

  ngOnInit(): void {
    this._service.getStudents().subscribe({
      next: (students: IStudent[]) => {
        console.log(students);
        this.students = new MatTableDataSource<IStudent>(students);
        this.students.paginator = this.paginator;
        this.students.sort = this.sort;
      },
      error: (error: HttpErrorResponse) => {
        this.HandleError(error);
      }
    })
  }

  HandleError(error: HttpErrorResponse) {
    console.log(error);
  }

}
