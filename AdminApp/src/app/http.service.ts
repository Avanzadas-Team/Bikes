import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor(private http: HttpClient) { }
  BaseURL = 'https://localhost:5001'

  getProducts() {
    return this.http.get(this.BaseURL + '/sa/prods');
  }
  getProdNY(id: string, dateS: string, dateE: string) {
    return this.http.get(this.BaseURL + '/sa/NY/' + id + '/' + dateS + '/' + dateE);
  }
  getProdCA(id: string, dateS: string, dateE: string) {
    return this.http.get(this.BaseURL + '/sa/CA/' + id + '/' + dateS + '/' + dateE);
  }
  getProdTX(id: string, dateS: string, dateE: string) {
    return this.http.get(this.BaseURL + '/sa/TX/' + id + '/' + dateS + '/' + dateE);
  }

}
