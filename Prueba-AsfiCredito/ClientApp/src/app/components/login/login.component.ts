import { Component } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { ClientService } from '../../services/client/client.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  formAutenticacion = new FormGroup({
    email: new FormControl(''),
    password: new FormControl('')
  });

  constructor(
    private clientService: ClientService,
    private router: Router,
    private route: ActivatedRoute
  ) {
    this.cargarForm();
  }

  cargarForm() {
    this.formAutenticacion = new FormGroup({
      email: new FormControl(''),
      password: new FormControl('')
    });
  }

  proximamente() {
    alert("Funcion en Desarrollo");
  }

  ingresar() {
    const email = this.formAutenticacion.value.email;
    const password = this.formAutenticacion.value.password;
    this.clientService.getClienteByEmailAndPassword(email, password).subscribe(res => {
      console.log(res);
      this.router.navigate(["/home"]);
    }, err => {
      alert("*** Error *** \n Your email or password is incorrect or not registred");
    });
  }

  forgotPasswd() {
    this.router.navigate(["/forgot-passwd"])
  }

}
