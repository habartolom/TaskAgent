import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ClientService {

  constructor(private http: HttpClient) { }

  public url = 'localhost';
  public port = 7090;

  public getAllClientes() {
    return this.http.get('https://' + this.url + ":" + this.port + "/api/client");
  }

  public getClienteByEmailAndPassword(email: string, password: string) {
    return this.http.get('https://' + this.url + ":" + this.port + "/api/client/" + email + "/" + password);
  }

  public getClienteByEmail(email: string) {
    return this.http.get('https://' + this.url + ":" + this.port + "/api/client/" + email);
  }

  public InsertClient(array: any) {
    return this.http.post('https://' + this.url + ":" + this.port + "/api/client", array);
  }

  public UpdateClient(array: any, id: string) {
    return this.http.put('https://' + this.url + ":" + this.port + "/api/client/" + id, array);
  }

  public DeleteClient(id: string) {
    return this.http.delete('https://' + this.url + ":" + this.port + "/api/client/" + id);
  }

}
