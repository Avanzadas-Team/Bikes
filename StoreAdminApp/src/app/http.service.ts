import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor(private http: HttpClient) { }
  BaseURL = 'https://localhost:5001'

  getAvgPbyCltNY(dateS: string, dateF: string) {
    return this.http.get(this.BaseURL + '/avgp/NY/' + dateS + '/' + dateF);
  }
  getAvgPbyCltCA(dateS: string, dateF: string) {
    return this.http.get(this.BaseURL + '/avgp/CA/' + dateS + '/' + dateF);
  }
  getAvgPbyCltTX(dateS: string, dateF: string) {
    return this.http.get(this.BaseURL + '/avgp/TX/' + dateS + '/' + dateF);
  }
}
