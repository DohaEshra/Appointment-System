import { FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GetAppointmentsComponent } from './get-appointments/get-appointments.component';



@NgModule({
  declarations: [
    GetAppointmentsComponent
  ],
  imports: [
    CommonModule, FormsModule
  ]
})
export class AdminModule { }
