import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { ConserviceService } from 'src/app/services/conservice.service';

@Component({
  selector: 'app-doctor-schedule',
  templateUrl: './doctor-schedule.component.html',
  styleUrls: ['./doctor-schedule.component.css']
})
export class DoctorScheduleComponent implements OnInit {
public result:any=[];
  constructor(private con:ConserviceService, private router:Router) { 
    
  } 
  GetSchedule(Formdata:NgForm):void{
    if(Formdata.value.doctorName==""){
    alert("enter you name");
    this.router.navigate(['doctorSchedule']);}

    this.result=this.con.GetScadule(Formdata.value.doctorName);

  }
  ngOnInit(): void {
  }

}
