import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BookAppointmentsComponent } from './book-appointments/book-appointments.component';



@NgModule({
  declarations: [
    BookAppointmentsComponent
  ],
  imports: [
    CommonModule, FormsModule, ReactiveFormsModule
  ]
})
export class UserModule { } 
