import { TotalSales } from './../../models/totalsales';
import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';

@Component({
  selector: 'app-total-sales',
  templateUrl: './total-sales.component.html',
  styleUrls: ['./total-sales.component.css']
})
export class TotalSalesComponent implements OnInit {

  public totalSale: TotalSales = {totalSales : 0};


  constructor(http: HttpClient) {
    http.get<TotalSales>('https://localhost:5001/' + 'totalsales').subscribe(result => {
      this.totalSale = result;
    }, error => console.error(error));
   }
  ngOnInit(): void {
  }

}
