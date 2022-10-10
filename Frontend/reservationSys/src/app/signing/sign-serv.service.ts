import { User } from './../_Models/user';
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Router } from '@angular/router';
@Injectable({
  providedIn: 'root'
})
export class SignServService {
  constructor(public http:HttpClient , public router : Router ) { }

  baseUrl="https://localhost:7036/api/";

  login(userName:string, passWord:string){
    return this.http.post<{token:string, role:string}>(this.baseUrl+"Login?username="+userName+"&password="+passWord, null)
  }
  register(user:User){
    return this.http.post<User>(this.baseUrl+"Users",user)

  }
  getToken()
  {
    return localStorage.getItem("token")
  }
}
