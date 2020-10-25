import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NullTemplateVisitor } from '@angular/compiler';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private auth: HttpClient) { }

  status: boolean = false;

  setUser(user): void {
    localStorage.setItem('currentUser', user);
  }
  setStore(store): void {
    localStorage.setItem('currentStore', store);
  }

  setStoreID(storeID): void {
    localStorage.setItem('currentStoreID', storeID);
  }

  getStore() {
    let store = localStorage.getItem('currentStore');
    if (store != null || store != undefined) {
      return store
    }
    else {
      return null;
    }
  }

  getStoreID() {
    let storeID = localStorage.getItem('currentStoreID');
    if (storeID != null || storeID != undefined) {
      return storeID
    }
    else {
      return null;
    }
  }

  getUser() {
    let user = localStorage.getItem('currentStore');
    if (user != null || user != undefined) {
      return user
    }
    else {
      return null;
    }
  }

  logOut(): void {
    localStorage.removeItem('currentUser');
    localStorage.removeItem('currentStore');
    localStorage.removeItem('currentStoreID');
    this.status = false;
  }

  logIn(user, store, storeID): void {
    this.setUser(user);
    this.setStore(store);
    this.setStoreID(storeID);
    this.status = true;
  }

  isLoggedIn(): boolean {
    if (this.status) {
      return true
    } else {
      return false;
    }
  }

}


