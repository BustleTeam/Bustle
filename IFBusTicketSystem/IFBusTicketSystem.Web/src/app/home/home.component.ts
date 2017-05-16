import { Component } from '@angular/core';

import { User } from '../_models/user';

import { Http, Headers, Response } from '@angular/http';

@Component({
  moduleId: module.id,
  templateUrl: 'home.component.html'
})

export class HomeComponent{
  currentUser: User;

  constructor(private http: Http) {
    var headers = new Headers();
    headers.append('Authorization', 'Bearer DOWjSZZTwVZy_t4Fdivlbj3H64x4d9e1zlfwVHzAPzbfpSFuxIY9A6cFZ6jgL_HOPOlhdDCbRHKPqUYOKVz_eevXH6PdBi2lhfptpGWK_IstcfWxVkgADZfK_MLBqwwNAMJxMB_fY--SjM8d6kesefr5h9t1Wa_YCkzQesSpnUNodg3OtpKSsf1ISF0bMv4cizPdtrnxCLNiBrUwndgQJvsqxpxPFxLTgcznKwgK6VU');

    this.http.get("http://localhost:62390/api/users/userdata", { headers: headers })
      .subscribe(data => this.currentUser = JSON.parse(data.json()));

    this.currentUser = JSON.parse(localStorage.getItem('currentUser'));
  }
}