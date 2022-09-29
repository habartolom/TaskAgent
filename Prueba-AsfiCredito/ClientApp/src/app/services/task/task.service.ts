import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TaskModel } from 'src/app/common/models/task-model';

@Injectable({
  providedIn: 'root'
})
export class TaskService {

  constructor(private http: HttpClient) { }

  public url = 'localhost';
  public port = 7053;

  public getAllTasks() : Observable<TaskModel[]> {
    return this.http.get<any>('https://' + this.url + ":" + this.port + "/api/CustomTask");
  }

  public getTaskById(id: string) : Observable<TaskModel> {
    return this.http.get<any>('https://' + this.url + ":" + this.port + "/api/CustomTask/" + id);
  }

  public InsertTask(array: any) {
    return this.http.post('https://' + this.url + ":" + this.port + "/api/CustomTask", array);
  }

  public UpdateTask(array: any, id: string) {
    return this.http.put('https://' + this.url + ":" + this.port + "/api/CustomTask/" + id, array);
  }

  public DeleteTask(id: string) {
    return this.http.delete('https://' + this.url + ":" + this.port + "/api/CustomTask/" + id);
  }

}
