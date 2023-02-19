import { HttpErrorResponse } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { UsersService } from '../users.service';

type Option = {
  value: number,
  display: string
}

@Component({
  selector: 'app-user-create',
  templateUrl: './user-create.component.html',
  styleUrls: ['./user-create.component.scss']
})
export class UserCreateComponent {

  roleOptions: Option[] = [
    { value: 0, display: 'Admin' },
    { value: 1, display: 'Consultant' },
    { value: 2, display: 'Teacher' },
    { value: 3, display: 'Instructor' },
  ];
 
  isChecked: boolean = false;
  isProperty: boolean = true;

  form = new FormGroup({
    username: new FormControl('', Validators.required),
    email: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', Validators.required),
    role: new FormControl('', Validators.required),
  });

  constructor(private _userService: UsersService, private _toastr: ToastrService) {
  }

  onSubmit() {
    this._userService.createUser(this.form.value).subscribe(value => {
      this._toastr.success("User successfully created", "Success");
      this.form.reset();
    });
  }

  getErrorMessage(control: any) {
    if (control.hasError('required')) {
      return 'You must enter a value';
    }

    return control.hasError('email') ? 'Not a valid email' : '';
  }

  HandleError(error: HttpErrorResponse) {
    console.log(error);
    this._toastr.error(error.message, error.statusText);
  }
}
