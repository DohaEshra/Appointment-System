import { Appointment } from './../_Models/appointment';
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Router } from '@angular/router';
import { Speciality } from '../_Models/speciality';
import { formatDate } from "@angular/common";

@Injectable({
  providedIn: 'root'
})
export class UserServService {
  constructor(public http:HttpClient , public router : Router) { }
  baseUrl="https://localhost:7036/api/";
  // https://localhost:7036/api/Appointments?specID=5&date=10-11-2022
  // 'https://localhost:7036/api/Appointments?specID=0&date=10-18-2022'
  // https://localhost:7036/api/Appointments?specID=0&date=Invalid%20Date'
  Book(SpecName:string, date:Date){
    return this.http.post<any>(this.baseUrl+"Appointments?specName="+SpecName+"&date="+formatDate(date,"MM-dd-yyyy", 'en-US'),null);
  }
  getSpecialities(){
    return this.http.get<string[]>(this.baseUrl+"Specialities");
  }  
  getSpeciality(name:string){
    return this.http.get<number>(this.baseUrl+"Specialities/"+name);
  }
}
