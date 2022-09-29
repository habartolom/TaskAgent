import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { TaskComponent } from './components/task/task.component';
import { TimerComponent } from './components/timer/timer.component';
import { TaskSetComponent } from './components/task-set/task-set.component';
import { TimeTrackingComponent } from './components/time-tracking/time-tracking.component';
import { FilterComponent } from './components/filter/filter.component';
import { AddTimeslipComponent } from './components/add-timeslip/add-timeslip.component';
import { FormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    DashboardComponent,
    TaskComponent,
    TimerComponent,
    TaskSetComponent,
    TimeTrackingComponent,
    FilterComponent,
    AddTimeslipComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    RouterModule.forRoot(
      [
        { path: 'timeTracking', component: TimeTrackingComponent },
      ]
    )
  ]
})
export class TaskDashboardModule { }
