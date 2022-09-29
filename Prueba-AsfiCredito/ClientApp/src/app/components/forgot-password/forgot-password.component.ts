import { Component } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { ClientService } from '../../services/client/client.service';

@Component({
  selector: 'app-forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrls: ['./forgot-password.component.css']
})
export class ForgotPasswordComponent {

  formResetPassword = new FormGroup({
    email: new FormControl('')
  });

  constructor(
    private clientService: ClientService
  ) {
    this.cargarForm();
  }

  cargarForm() {
    this.formResetPassword = new FormGroup({
      email: new FormControl('')
    });
  }

  enviarPasswd() {
    const email = this.formResetPassword.value.email;
    this.clientService.getClienteByEmail(email).subscribe(res => {
      const resp = res as any;
      alert("Your password is : "+resp.password);
    }, error => {
      alert("*** ERROR *** \n The email is incorrect or not registred ");
    })
  }

}
