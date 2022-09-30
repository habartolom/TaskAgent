import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DepartmentModel } from 'src/app/common/models/department-model';
import { TaskDepartmentModel } from 'src/app/common/models/task-department-model';
import { DepartmentService } from 'src/app/services/department/department.service';
import { TaskService } from 'src/app/services/task/task.service';

@Component({
  selector: 'app-tasks',
  templateUrl: './tasks.component.html',
  styleUrls: ['./tasks.component.css']
})
export class TasksComponent implements OnInit {

  public tasks: TaskDepartmentModel[];
  public departments: DepartmentModel[];
  public departmentSelected: DepartmentModel;
  public description: string;

  constructor(
    private taskService: TaskService,
    private departmentService: DepartmentService,
    private router: Router
  ) {
    this.description = '';
  }

  ngOnInit() {
    if(sessionStorage.getItem('client') == null)
      this.router.navigate(['/']);

    this.departmentService.getAllDepartments().subscribe(response => {
      this.departments = response;
    })

    this.getTasks();
  }

  addTask(){
    if(this.departmentSelected == null || this.description == null)
      return;

      const newTask = {
      departmentId: this.departmentSelected.id,
      description: this.description
    }

    this.taskService.InsertTask(newTask).subscribe(response => {
      this.getTasks();
    })
  }

  getTasks(){
    this.taskService.getAllTasksIncludeDepartment().subscribe(response => {
      this.tasks = response;
    })
  }
}
