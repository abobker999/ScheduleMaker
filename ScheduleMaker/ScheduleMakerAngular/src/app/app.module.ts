import { NgModule } from '@angular/core';
import {HttpClientModule} from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms'
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ConserviceService } from './services/conservice.service';
import { CreateScheduleComponent } from './Components/create-schedule/create-schedule.component';
import { AddDoctorComponent } from './Components/add-doctor/add-doctor.component';
import { DoctorScheduleComponent } from './Components/doctor-schedule/doctor-schedule.component';

@NgModule({
  declarations: [
    AppComponent,
    CreateScheduleComponent,
    AddDoctorComponent,
    DoctorScheduleComponent
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule
  ],
  providers: [ConserviceService],
  bootstrap: [AppComponent]
})
export class AppModule { }
