import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AuthenticationService } from '../shared/services/authentication.service';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.scss']
})
export class AccountComponent {
  private model: any = {
    email: "",
    password: ""
  }

  constructor(private _authService: AuthenticationService) { }

  onSubmit(formData: NgForm) {
    this.model = formData.value;

    this._authService.authUserWithCredentials(this.model);
  }
}
