import { Speciality } from 'src/app/_Models/speciality';
import { Component, OnInit } from '@angular/core';
import { UserServService } from 'src/app/user/user-serv.service';
import { AdminServService } from '../admin-serv.service';

@Component({
  selector: 'app-get-appointments',
  templateUrl: './get-appointments.component.html',
  styleUrls: ['./get-appointments.component.css']
})
export class GetAppointmentsComponent implements OnInit {
  dat:string = "";
  date:Date|null=null;
time:number=0;  
speciality:string=""
s:string[]=[];
speci:number=0;
specialities:Speciality[]=[]
constructor(public usrServ:UserServService, public adminServ:AdminServService) {}

  ngOnInit(): void {
    this.usrServ.getSpecialities().subscribe(
      data=>{
        this.s=data
        console.log(this.s)
    })
  }
  search(specii:string){
    this.usrServ.getSpeciality(specii).subscribe(a=>this.speci=a)

    this.date?.setDate(Number(this.dat))
    this.date?.setTime(this.time)
    this.adminServ.GetAppointments(this.speci, this.date).subscribe(a=>console.log(a))
  }

}
