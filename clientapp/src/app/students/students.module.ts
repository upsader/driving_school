import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { StudentsRoutingModule } from './students-routing.module';
import { StudentsComponent } from './students.component';
import { StudentService } from './students.service';

@NgModule({
    declarations: [
        StudentsComponent
    ],
    imports: [
        SharedModule,
        StudentsRoutingModule
    ],
    providers: [
        StudentService
    ]
  })
  export class StudentsModule { }