import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AdminServService {
  baseUrl="https://localhost:7036/api/";

  constructor(public http:HttpClient , public router : Router) { }
  GetAppointments(speciality:number, date:Date|null){
    return this.http.get(this.baseUrl+"Admin?speciality="+speciality+"&date="+date)
  }
}
