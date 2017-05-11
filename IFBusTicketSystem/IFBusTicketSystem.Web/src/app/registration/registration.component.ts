import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { AlertService } from '../_services/alert.service';
import { RegistrationService } from './registration.service';

@Component({
  selector: 'register',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css'],
  providers: [
    RegistrationService,
    AlertService
  ]
})
export class RegistrationComponent {
  model: any = {};
  loading = false;

  constructor(
    private router: Router,
    private service: RegistrationService,
    private alertService: AlertService) { }

  register() {
    this.loading = true;
    this.service.register(this.model)
      .subscribe(
      data => {
        this.alertService.success('Registration successful', true);
        this.router.navigate(['/']);
      },
        error => {
          this.alertService.error(error);
          this.loading = false;
        });
  }
  
}