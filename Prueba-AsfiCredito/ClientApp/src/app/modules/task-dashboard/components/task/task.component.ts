import { Component, Input, Output, OnInit, EventEmitter } from '@angular/core';
import { DashboardTimeslipModel } from 'src/app/common/models/dashboardtimeslip-model';
import { DashboardService } from 'src/app/services/dashboard/dashboard.service';
import { TimeSlipService } from 'src/app/services/timeSlip/time-slip.service';

@Component({
  selector: 'app-task',
  templateUrl: './task.component.html',
  styleUrls: ['./task.component.css']
})
export class TaskComponent implements OnInit {

  @Input() timeslip: DashboardTimeslipModel;

  public clientUserName: string;
  public clientId: string;

  constructor(
    private timeslipService: TimeSlipService,
    private dashboardService: DashboardService
  ) { }

  ngOnInit() {
    const json = sessionStorage.getItem('client');
    const client = JSON.parse(json);

    this.clientUserName = client.userName;
  }

  removeTimeslip(){
    this.timeslipService.DeleteTimeSlip(this.timeslip.timeSlipId).subscribe(() => {
      this.dashboardService.emitChangeDashboardEvent();
    });
  }
}
