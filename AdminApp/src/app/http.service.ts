import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor(private http: HttpClient) { }
  BaseURLNY = 'https://localhost:5001';
  BaseURLCA = 'https://localhost:5003';
  BaseURLTX = 'https://localhost:5005';


  getProducts() {
    return this.http.get(this.BaseURLNY + '/sa/prods');
  }
  getProdNY(id: string, dateS: string, dateE: string) {
    return this.http.get(this.BaseURLNY + '/sa/NY/' + id + '/' + dateS + '/' + dateE);
  }
  getProdCA(id: string, dateS: string, dateE: string) {
    return this.http.get(this.BaseURLCA + '/sa/CA/' + id + '/' + dateS + '/' + dateE);
  }
  getProdTX(id: string, dateS: string, dateE: string) {
    return this.http.get(this.BaseURLTX + '/sa/TX/' + id + '/' + dateS + '/' + dateE);
  }

}
