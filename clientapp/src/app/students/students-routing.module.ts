import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from '../shared/services/auth.guard.service';
import { StudentsComponent } from './students.component';

const routes: Routes = [
  { path: '', component: StudentsComponent, canActivate: [AuthGuard]},
  { path: '**', redirectTo: '', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})

export class StudentsRoutingModule { }
