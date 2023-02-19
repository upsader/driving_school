import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { UsersService } from './users.service';
import { IUser } from '../shared/models/user';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.scss']
})
export class UsersComponent implements OnInit {

  public displayedColumns: string[] = ['email', 'username', 'role', 'action'];
  public users: MatTableDataSource<IUser> = new MatTableDataSource<IUser>();

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(private _service: UsersService, private _router: Router, private _toastr: ToastrService) { }

  ngOnInit(): void {
    this._service.getUsers().subscribe({
      next: (users: IUser[]) => {
        this.users = new MatTableDataSource<IUser>(users);
        this.users.paginator = this.paginator;
        this.users.sort = this.sort;
      },
      error: (error: HttpErrorResponse) => {
        this.HandleError(error);
      }
    })
  }

  createUser(){
    this._router.navigate(['users/create']);
  }

  deleteUser(email: string) {
    this._service.deleteUser(email).subscribe(value => {
      this._toastr.success("User successfully deleted", "Success");
      this.ngOnInit();
    });
  };

  HandleError(error: HttpErrorResponse) {
    console.log(error);
  }

}
