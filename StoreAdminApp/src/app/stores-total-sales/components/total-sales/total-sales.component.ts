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

  port : string = "";

  constructor(http: HttpClient) {
    var storeID = localStorage.getItem('currentStoreID');
    if(storeID == "1"){
      this.port = "5001";
    }
    if(storeID == "2"){
      this.port = "5003";
    }
    if(storeID == "3"){
      this.port = "5005";
    }

    http.get<TotalSales>('https://localhost:' + this.port  + '/' + 'totalsales').subscribe(result => {
      this.totalSale = result;
    }, error => console.error(error));
   }
  ngOnInit(): void {
  }

}
