import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { ConserviceService } from 'src/app/services/conservice.service';

@Component({
  selector: 'app-add-doctor',
  templateUrl: './add-doctor.component.html',
  styleUrls: ['./add-doctor.component.css']
})
export class AddDoctorComponent implements OnInit {

  constructor(private con:ConserviceService, private router:Router) { 
    
  } 
public result:any;
  addDoctor(Formdata:NgForm):void{
    if(Formdata.value.doctorName==""){

      alert("the doctorName required");
      this.router.navigate(['']);
    }
    this.result=this.con.AddDoctor(Formdata.value.doctorName);

  }

  ngOnInit(): void {
  }

}
