import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddDoctorComponent } from './Components/add-doctor/add-doctor.component';
import { CreateScheduleComponent } from './Components/create-schedule/create-schedule.component';
import { DoctorScheduleComponent } from './Components/doctor-schedule/doctor-schedule.component';

const routes: Routes = [
  {path:"",component:CreateScheduleComponent},
  {path:"addDoctor",component:AddDoctorComponent},
  {path:"doctorSchedule",component:DoctorScheduleComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
