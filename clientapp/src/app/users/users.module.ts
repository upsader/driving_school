import { NgModule } from '@angular/core';
import { UsersRoutingModule } from './users-routing.module';
import { SharedModule } from '../shared/shared.module';
import { UsersComponent } from './users.component';
import { UsersService } from './users.service';
import { UserCreateComponent } from './user-create/user-create.component';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [
    UsersComponent,
    UserCreateComponent
  ],
  imports: [
    UsersRoutingModule,
    SharedModule
  ],
  providers: [
    UsersService
  ]
})
export class UsersModule { }
