import { Injectable } from '@angular/core';
import { retry, catchError } from 'rxjs/operators';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Formdata } from '../Components/create-schedule/FormData'
import { Observable,throwError  } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class ConserviceService {
  public url= 'https://localhost:44395/api';
  constructor(private httpClint:HttpClient ){
  }
 
  httpHeader = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  } 
  
  public GetScadule(doctorName:string):Observable<string>{
    return this.httpClint.post<string>(this.url+'/GetSchedule',doctorName,this.httpHeader)
    .pipe(
      retry(1),
      catchError(this.processError)
      )

  } 
  public DoSchedule(formData: Formdata): Observable<Formdata> {
    return this.httpClint.post<Formdata>(this.url + '/DoSchedule', formData, this.httpHeader)
      .pipe(
        retry(1),
        catchError(this.processError)
      )
  }
  public AddDoctor(doctorName: string):Observable<string> {
    return this.httpClint.post<string>(this.url + '/AddDoctor', doctorName, this.httpHeader)
    .pipe(
      retry(1),
      catchError(this.processError)
      )
      
  }
  public GetAllDoctors() {
      this.httpClint.get(this.url + '/GetAllDoctor');
  }

  processError(err: any) {
    let message = '';
    if (err.error instanceof ErrorEvent) {
      message = err.error.message;
    } else {
      message = `Error Code: ${err.status}\nMessage: ${err.message}`;
    }
    console.log(message);
    return throwError(message);
  }
    
}
