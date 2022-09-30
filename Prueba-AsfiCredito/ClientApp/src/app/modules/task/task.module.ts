import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { TasksComponent } from './components/tasks/tasks.component';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    TasksComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    RouterModule.forChild(
      [
        { path: 'tasks', component: TasksComponent },
      ]
    )
  ]
})
export class TaskModule { }
