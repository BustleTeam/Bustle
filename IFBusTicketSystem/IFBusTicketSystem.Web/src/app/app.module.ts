import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { routing } from './app.routing';

import { AppComponent } from './app.component';
import { RegistrationComponent } from './registration/registration.component'
import { AlertComponent } from './_directives/alert.component';

@NgModule({
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    routing
  ],
  declarations: [
    AppComponent,
    RegistrationComponent,
    AlertComponent
  ],
  bootstrap:    [ AppComponent ]
})
export class AppModule { }
