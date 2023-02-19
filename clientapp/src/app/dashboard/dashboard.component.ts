import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IUser } from '../shared/models/user';
import { AuthenticationService } from '../shared/services/authentication.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent {

  constructor(private _router: Router, public authService: AuthenticationService) {
  }

  studentsList(){
    this._router.navigate(['/students']);
  }
  usersList(){
    this._router.navigate(['/users']);
  }
}
