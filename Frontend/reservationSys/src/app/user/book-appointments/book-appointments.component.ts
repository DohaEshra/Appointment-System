import { Component, OnInit, OnChanges, SimpleChanges } from '@angular/core';
import { Appointment } from 'src/app/_Models/appointment';
import { Speciality } from 'src/app/_Models/speciality';
import { UserServService } from '../user-serv.service';
import { Observable, of } from "rxjs";
import { User } from 'src/app/_Models/user';

@Component({
  selector: 'app-book-appointments',
  templateUrl: './book-appointments.component.html',
  styleUrls: ['./book-appointments.component.css']
})
export class BookAppointmentsComponent implements OnInit  {
dat:string = "";
time:number=0;
id:number=0;
spec:string="";
s:string[]=[];

flag:number = 0;
  constructor(public usrServ:UserServService) {}

  ngOnInit(): void {
        this.usrServ.getSpecialities().subscribe(
        data=>{
          this.s=data
          console.log(this.s)
      })

    }
    

    Book(){
      let date = new Date(this.dat);
    console.log(date)
    console.log(this.dat)
    console.log(this.id)
    this.usrServ.Book(this.spec,date).subscribe(a=>{
      console.log(a)
    }) 
  }
  sleep(ms:number) {
    return new Promise(resolve => setTimeout(resolve, ms));
  }
}
