import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ConserviceService } from 'src/app/services/conservice.service';
import { Formdata } from '../create-schedule/FormData'
import { NgForm} from '@angular/forms';


@Component({
  selector: 'app-create-schedule',
  templateUrl: './create-schedule.component.html',
  styleUrls: ['./create-schedule.component.css']
})
export class CreateScheduleComponent implements OnInit {
  public result:any; 
  public AllDoctor:any=[];

  constructor(private con:ConserviceService, private router:Router) { 
    
  } 
  DoScadelule(Formdata:NgForm): void { 
    if(Formdata.value.startDate==""||Formdata.value.endDate==""||Formdata.value.doctorName==""||Formdata.value.sessionTime==""||Formdata.value.WatingTime=="") {
      alert("all data required");
      this.router.navigate(['']);
    } 
     //const Formdata=formData.value      
     this.result=this.con.DoSchedule(Formdata.value)
     alert("your Booikng is "+ this.result);
  }
  ngOnInit(): void {   
 this.AllDoctor=this.con.GetAllDoctors();
  }
}
