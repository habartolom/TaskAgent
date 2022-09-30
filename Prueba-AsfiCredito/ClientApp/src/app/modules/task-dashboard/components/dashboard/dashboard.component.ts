import { Component, Input, OnChanges, OnInit,  SimpleChanges } from '@angular/core';
import { DashboardTimeslipModel } from 'src/app/common/models/dashboardtimeslip-model';
import { TimeslipDateModel } from 'src/app/common/models/timeslip-date-model';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit, OnChanges {

  @Input() dashboardTimeslips: DashboardTimeslipModel[];

  public timeslipsByDate: TimeslipDateModel[];

  constructor() {}

  ngOnInit() {}

  ngOnChanges(changes: SimpleChanges): void {

    if (changes['dashboardTimeslips'] && this.dashboardTimeslips != null){
      this.timeslipsByDate = [];
      const timeslipDates = this.dashboardTimeslips.map(x => x.executionTruncateDate);
      const dates = timeslipDates.filter((value, index) => timeslipDates.indexOf(value) == index);

      dates.forEach(date => {
        const timeslipDate : TimeslipDateModel = {
          date: date,
          timeslips: this.dashboardTimeslips.filter(x => x.executionTruncateDate == date)
        }
        this.timeslipsByDate.push(timeslipDate)
      });
    }
  }
}
