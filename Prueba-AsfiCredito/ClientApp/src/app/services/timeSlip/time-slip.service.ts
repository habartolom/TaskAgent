import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { DashboardTimeslipModel } from 'src/app/common/models/dashboardtimeslip-model';
import { TimeSlipModel } from 'src/app/common/models/timeslip-model';

@Injectable({
  providedIn: 'root'
})
export class TimeSlipService {

    constructor(private http: HttpClient) { }

    public url = 'localhost';
    public port = 7053;

    public getAllTimeSlips() : Observable<TimeSlipModel[]> {
      	return this.http.get<any>('https://' + this.url + ":" + this.port + "/api/TaskTimeSlip");
    }

    public getTimeSlipById(id: string) : Observable<TimeSlipModel> {
      	return this.http.get<any>('https://' + this.url + ":" + this.port + "/api/TaskTimeSlip/" + id);
    }

    public getTimeSlipByClientId(id: string) : Observable<DashboardTimeslipModel[]> {
      return this.http.get<any>('https://' + this.url + ":" + this.port + "/api/TaskTimeSlip/Client/" + id);
  }

    public InsertTimeSlip(array: any) {
      	return this.http.post('https://' + this.url + ":" + this.port + "/api/TaskTimeSlip", array);
    }

    public UpdateTimeSlip(array: any, id: string) {
      	return this.http.put('https://' + this.url + ":" + this.port + "/api/TaskTimeSlip/" + id, array);
    }

    public DeleteTimeSlip(id: string) {
      	return this.http.delete('https://' + this.url + ":" + this.port + "/api/TaskTimeSlip/" + id);
    }

}
