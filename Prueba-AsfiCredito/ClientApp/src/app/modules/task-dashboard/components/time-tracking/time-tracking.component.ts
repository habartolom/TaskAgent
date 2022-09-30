import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DashboardTimeslipModel } from 'src/app/common/models/dashboardtimeslip-model';
import { TimeslipDateModel } from 'src/app/common/models/timeslip-date-model';
import { DashboardService } from 'src/app/services/dashboard/dashboard.service';
import { ModalService } from 'src/app/services/modal/modal.service';
import { TimeSlipService } from 'src/app/services/timeSlip/time-slip.service';

@Component({
  selector: 'app-time-tracking',
  templateUrl: './time-tracking.component.html',
  styleUrls: ['./time-tracking.component.css']
})
export class TimeTrackingComponent implements OnInit {


  public clientId : string;
  public dashboardTimeslips: DashboardTimeslipModel[];
  public timeslipsByDate: TimeslipDateModel[];
  public showModal: boolean;

  constructor(
    private timeslipService: TimeSlipService,
    private dashboardService: DashboardService,
    private modalService: ModalService,
    private router: Router
  )
  {
    this.showModal = false;
  }

  ngOnInit() {

    if(sessionStorage.getItem('client') == null)
      this.router.navigate(['/']);

    const json = sessionStorage.getItem('client');
    const client = JSON.parse(json);
    this.clientId = client.id;

    this.getDashboard();

    this.dashboardService.changeDashboardEventListener().subscribe(() => {
      this.getDashboard();
    });

    this.modalService.showModalEventListener().subscribe((msg)=> {
      this.showModal = msg;
    });
  }

  getDashboard(){
    this.timeslipService.getTimeSlipByClientId(this.clientId).subscribe(response => {
      this.dashboardTimeslips = response;
    })
  }
}
