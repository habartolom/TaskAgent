import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ClientService } from '../../services/client/client.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {

  clientes: any;

  constructor(
    private clientService: ClientService,
    private router: Router,
    private route: ActivatedRoute
  ) {
    this.cargarClientes();
  }

  cargarClientes() {
    this.clientService.getAllClientes().subscribe(res => {
      const resp = res as any;
      this.clientes = resp;
      console.log(this.clientes);
    });
  }



}
