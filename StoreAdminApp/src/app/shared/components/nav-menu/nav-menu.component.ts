import { AuthService } from './../../../auth.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {

  constructor(private auth: AuthService) { }

  storeName = '';

  ngOnInit(): void {
  }

  checkStatus(): boolean {
    this.storeName = this.auth.getStore();
    return this.auth.isLoggedIn();
  }

  onLogOut() {
    this.auth.logOut();
    this.storeName = "Store Name"
  }




}
