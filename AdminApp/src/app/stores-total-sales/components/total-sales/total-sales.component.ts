import { Store } from './../../../client-boughts/models/store';
import { TotalSales } from './../../models/totalsales';
import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { Console } from 'console';

@Component({
  selector: 'app-total-sales',
  templateUrl: './total-sales.component.html',
  styleUrls: ['./total-sales.component.css']
})
export class TotalSalesComponent implements OnInit {

  public totalSale: TotalSales = {totalSales : 0};


  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<TotalSales>(baseUrl + 'totalsales').subscribe(result => {
      this.totalSale = result;
    }, error => console.error(error));
   }
  ngOnInit(): void {
  }

}
