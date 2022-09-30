import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'app';

  public logged: boolean;

  constructor() {
      const client =  sessionStorage.getItem('client');
      this.logged = client != null;
  }
}
