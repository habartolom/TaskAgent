import { Component } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { ClientService } from '../../services/client/client.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {

  formAutenticacion = new FormGroup({
    email: new FormControl(''),
    userName: new FormControl(''),
    password: new FormControl('')
  })

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
      userName: new FormControl(''),
      password: new FormControl('')
    })
  }

  registrar() {
    const array = ({
      Email: this.formAutenticacion.value.email,
      UserName: this.formAutenticacion.value.userName,
      Password: this.formAutenticacion.value.password
    })
    this.clientService.InsertClient(array).subscribe(res => {
      this.router.navigate(["/"]);
    }, err => {
      alert("*** ERROR *** \n The email or password or username is empty ");
    })
  }

}
