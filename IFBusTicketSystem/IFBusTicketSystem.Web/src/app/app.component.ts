import { Component } from '@angular/core';
import { RegistrationComponent } from './registration/registration.component' 

@Component({
  selector: 'my-app',
  template: '<a [routerLink]="[\'/register\']" class="btn btn-link">SIGN UP</a>' +
    '<router-outlet></router-outlet>'
})
export class AppComponent  { name = 'Angular'; }
