import { Component, OnInit } from '@angular/core';
import { DepartmentModel } from 'src/app/common/models/department-model';
import { TaskModel } from 'src/app/common/models/task-model';
import { DepartmentService } from 'src/app/services/department/department.service';
import { TaskService } from 'src/app/services/task/task.service';

@Component({
  selector: 'app-add-timeslip',
  templateUrl: './add-timeslip.component.html',
  styleUrls: ['./add-timeslip.component.css']
})
export class AddTimeslipComponent implements OnInit {

  public departments: DepartmentModel[];
  public tasks: TaskModel[];
  public departmentTasks: TaskModel[];

  public optionDepartmentSelected: DepartmentModel;
  public optionTaskSelected: TaskModel;

  constructor(
    private departmentService: DepartmentService,
    private taskService: TaskService
  ) {

  }

  ngOnInit() {
    this.departmentService.getAllDepartments().subscribe(response => {
      this.departments = response;
    })

    this.taskService.getAllTasks().subscribe(response => {
      this.tasks = response;
    })
  }

  onDepartmentChange(){
    this.departmentTasks = this.tasks.filter(x => x.departmentId == this.optionDepartmentSelected.id)
  }

  onTaskChange(){
    console.log(this.optionTaskSelected);
  }

  onStartTimer(){

  }

}
