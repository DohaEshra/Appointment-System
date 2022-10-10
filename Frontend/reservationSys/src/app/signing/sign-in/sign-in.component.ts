import { Component, OnInit } from '@angular/core';
import { RouterLink, RouterModule } from '@angular/router';
import { Router } from '@angular/router';
import { SignServService } from '../sign-serv.service';
import { Injectable } from '@angular/core';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
@Injectable({
  providedIn: null
})
export class SignInComponent implements OnInit {
  Username:string=""
  Password:string=""
  role=""
  constructor(public signSer:SignServService, public router:Router) { }

  ngOnInit(): void {
  }
  Login(usrname:string, pass:string){
    this.signSer.login(usrname, pass).subscribe(a=>{
      console.log(a.role)
      this.role = a.role
      sessionStorage.setItem("token", a.token)
    })
    this.role=="Admin"?this.router.navigateByUrl("/Admin"):this.router.navigateByUrl("/User")
  }
}
