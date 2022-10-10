import { GetAppointmentsComponent } from './admin/get-appointments/get-appointments.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SignInComponent } from './signing/sign-in/sign-in.component';
import { SignUpComponent } from './signing/sign-up/sign-up.component';
import { BookAppointmentsComponent } from './user/book-appointments/book-appointments.component';

const routes: Routes = [
  {path:"login", component:SignInComponent},
  {path:"register", component:SignUpComponent},
  {path:"Admin", component:GetAppointmentsComponent},
  {path:"User", component:BookAppointmentsComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
