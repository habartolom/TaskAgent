import { Component, Input, OnInit } from '@angular/core';
import { TimeslipDateModel } from 'src/app/common/models/timeslip-date-model';
import { ModalService } from 'src/app/services/modal/modal.service';

@Component({
  selector: 'app-task-set',
  templateUrl: './task-set.component.html',
  styleUrls: ['./task-set.component.css']
})
export class TaskSetComponent implements OnInit {

  @Input() timeslipGroup: TimeslipDateModel;

  public totalTimeByDate : string;

  constructor(
    private modalService: ModalService,
  ) { }

  ngOnInit() {
    const durations = this.timeslipGroup.timeslips.map(x => x.duration);

    let totalMinutes = 0;

    durations.forEach(duration => {
      const time = duration.split(':');
      totalMinutes += parseInt(time[0]) * 60;
      totalMinutes += parseInt(time[1]);
    })

    const hh = Math.floor(totalMinutes / 60);
    const mm = totalMinutes % 60;

    this.totalTimeByDate = mm < 10 ? `${hh}:0${mm}` : `${hh}:${mm}`;
  }

  addTimeSlip(){
    this.modalService.emitShowModalEvent(true);
  }
}
