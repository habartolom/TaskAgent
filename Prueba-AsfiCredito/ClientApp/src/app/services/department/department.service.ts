import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { DepartmentModel } from 'src/app/common/models/department-model';

@Injectable({
  providedIn: 'root'
})
export class DepartmentService {

  constructor(private http: HttpClient) { }

  public url = 'localhost';
  public port = 7053;

  public getAllDepartments(): Observable<DepartmentModel[]> {
    return this.http.get<any>('https://' + this.url + ":" + this.port + "/api/Department");
  }

  public getDepartmentById(id: string): Observable<DepartmentModel> {
    return this.http.get<any>('https://' + this.url + ":" + this.port + "/api/Department/" + id);
  }

  public InsertDepartment(array: any) {
    return this.http.post('https://' + this.url + ":" + this.port + "/api/Department", array);
  }

  public UpdateClient(array: any, id: string) {
    return this.http.put('https://' + this.url + ":" + this.port + "/api/Department/" + id, array);
  }

  public DeleteClient(id: string) {
    return this.http.delete('https://' + this.url + ":" + this.port + "/api/Department/" + id);
  }

}
