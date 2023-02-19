import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from '../shared/services/auth.guard.service';
import { UserCreateComponent } from './user-create/user-create.component';
import { UsersComponent } from './users.component';

const routes: Routes = [
  { path: '', component: UsersComponent, canActivate: [AuthGuard]},
  { path: 'create', component: UserCreateComponent, canActivate: [AuthGuard]},
  { path: '**', redirectTo: '', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})

export class UsersRoutingModule { }
