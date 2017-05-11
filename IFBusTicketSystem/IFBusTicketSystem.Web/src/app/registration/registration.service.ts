import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { RegisterUser } from './registration.model';
import 'rxjs/Rx';

@Injectable()
export class RegistrationService {
  constructor(private http: Http) { }

  register(command: RegisterUser) {
    return this.http.post("http://localhost:62390/api/users/register", command)
      .map((response: Response) => response.json())
      .catch((error: any) => 'Internal Server error');
  }
}