import { NgModule } from '@angular/core';
import { CommonModule, DatePipe } from '@angular/common';
import { RouterModule } from '@angular/router';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { TaskComponent } from './components/task/task.component';
import { TaskSetComponent } from './components/task-set/task-set.component';
import { TimeTrackingComponent } from './components/time-tracking/time-tracking.component';
import { AddTimeslipComponent } from './components/add-timeslip/add-timeslip.component';
import { FormsModule } from '@angular/forms';
import { ModalAddTimeslipComponent } from './components/modal-add-timeslip/modal-add-timeslip.component';
import { ModalTimeslipComponent } from './components/modal-timeslip/modal-timeslip.component';

@NgModule({
  declarations: [
    DashboardComponent,
    TaskComponent,
    TaskSetComponent,
    TimeTrackingComponent,
    AddTimeslipComponent,
    ModalAddTimeslipComponent,
    ModalTimeslipComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    RouterModule.forRoot(
      [
        { path: 'timeTracking', component: TimeTrackingComponent },
      ]
    )
  ],
  providers: [
    DatePipe
  ]
})
export class TaskDashboardModule { }
