import { AuthService } from './../../../auth.service';
import { Component, OnInit, Inject, ViewEncapsulation } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
  encapsulation: ViewEncapsulation.None,
})
export class LoginComponent implements OnInit {

  constructor(private auth: AuthService, private formBuilder: FormBuilder, private router: Router) {
    this.LogInForm = this.formBuilder.group({
      store: ['', Validators.required]
    })
  }

  storeSelected: String;
  LogInForm: FormGroup;
  Stores: string[] = ['New York - Baldwin Bikes', 'California - Santa Cruz Bikes', 'Texas - Rowlett Bikes'];
  cAdmin = 'jannette.david@bikes.shop';
  nyAdmin = 'mireya.copeland@bikes.shop';
  tAdmin = 'kali.vargas@bikes.shop';
  currentAdmin = '';


  onLogIn() {
    let storeID: number;
    if (this.storeSelected == 'New York - Baldwin Bikes') {
      this.currentAdmin = this.nyAdmin;
      storeID = 1;
    }
    else if (this.storeSelected == 'California - Santa Cruz Bikes') {
      this.currentAdmin = this.cAdmin;
      storeID = 2;
    }
    else {
      this.currentAdmin = this.tAdmin;
      storeID = 3;
    }
    this.auth.logIn(this.currentAdmin, this.storeSelected, storeID);
    
    this.router.navigate(["Create-sell"]);
    console.log(localStorage.getItem('currentStore'));
  }

  ngOnInit(): void {
  }

}