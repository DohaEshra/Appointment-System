import { SignInComponent } from './../sign-in/sign-in.component';
import { SignServService } from './../sign-serv.service';
import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/_Models/user';


@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit {
user:User=new User(0, "", "", "", "")
  constructor(public SignSer:SignServService, public signIn:SignInComponent) { }

  ngOnInit(): void {
  }
  register(user:User){
    this.SignSer.register(user).subscribe(a=>{
      console.log(a);
      this.signIn.Login(a.Username, a.Password)
    })
  }
}
