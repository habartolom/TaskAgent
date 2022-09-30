import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DepartmentModel } from 'src/app/common/models/department-model';
import { TaskModel } from 'src/app/common/models/task-model';
import { TimeSlipModel } from 'src/app/common/models/timeslip-model';
import { DashboardService } from 'src/app/services/dashboard/dashboard.service';
import { DepartmentService } from 'src/app/services/department/department.service';
import { ModalService } from 'src/app/services/modal/modal.service';
import { TaskService } from 'src/app/services/task/task.service';
import { TimeSlipService } from 'src/app/services/timeSlip/time-slip.service';

@Component({
  selector: 'app-modal-add-timeslip',
  templateUrl: './modal-add-timeslip.component.html',
  styleUrls: ['./modal-add-timeslip.component.css']
})
export class ModalAddTimeslipComponent implements OnInit {

  public departments: DepartmentModel[];
    public tasks: TaskModel[];
    public departmentTasks: TaskModel[];

    public today: string;
    public departmentSelected: DepartmentModel;
    public taskSelected: TaskModel;
    public timerStartDate: Date;
    public timerIsActive: boolean
    public timer: string;
    public comment: string;
    public clientId: string;
    public clientUserName: string;

    public interval: any;

    constructor(
      private departmentService: DepartmentService,
      private taskService: TaskService,
      private timeSlipService: TimeSlipService,
      private dashboardService: DashboardService,
      private modalService: ModalService,
      private router: Router,
      private datePipe: DatePipe
    ) {
      this.today = this.datePipe.transform(new Date(), 'yyyy-MM-dd');
      this.timerIsActive = false;
      this.timer = '0:00:00';
      this.comment = '';
    }

    ngOnInit() {
      const json = sessionStorage.getItem('client');
      const client = JSON.parse(json);

      this.clientId = client.id;
      this.clientUserName = client.userName;

      this.departmentService.getAllDepartments().subscribe(response => {
        this.departments = response;
      })

      this.taskService.getAllTasks().subscribe(response => {
        this.tasks = response;
      })

      if(this.clientId == null)
        this.router.navigate(['/']);
    }

    onDepartmentChange(){
      this.departmentTasks = this.tasks.filter(x => x.departmentId == this.departmentSelected.id)
    }

    startTimer(){

      if(this.departmentSelected == null || this.taskSelected == null)
        return;

      this.timerIsActive = true;

      let counter = 0;
      this.timerStartDate = new Date();

      this.interval = setInterval(() => {
        counter += 1;

        let hours = Math.floor(counter / 3600);
        let minutes = Math.floor(counter / 60) % 60;
        let seconds = counter % 60;

        let mm = minutes < 10 ? `0${minutes}` : `${minutes}`;
        let ss = seconds < 10 ? `0${seconds}` : `${seconds}`;
        this.timer = `${hours}:${mm}:${ss}`

        if(this.timerStartDate.getDate() < new Date().getDate()){
            this.stopTimer();
        }

      }, 1000)
    }

    stopTimer(){
      clearInterval(this.interval);

      const timeSlip : TimeSlipModel = {
        taskId: this.taskSelected.id,
        clientId: this.clientId,
        executionDate: this.timerStartDate,
        duration: this.timer.split(':').slice(0, 2).join(':'),
        comment: this.comment
      }

      this.departmentSelected = undefined;
      this.taskSelected = undefined;
      this.timerIsActive = false;
      this.timer = '0:00:00';
      this.comment = '';

      this.timeSlipService.InsertTimeSlip(timeSlip).subscribe(() => {
          this.dashboardService.emitChangeDashboardEvent();
          this.modalService.emitShowModalEvent(false);
      })
    }

    closeModal(){
      this.modalService.emitShowModalEvent(false);
    }
}
