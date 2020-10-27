import { ClientsID } from './../../models/ClientsID';
import { Component, OnInit, Inject, ViewEncapsulation} from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {MatCalendarCellClassFunction} from '@angular/material/datepicker';
import { Ordersdet } from '../../models/Ordersdet';




@Component({
  selector: 'app-number-of-orders',
  templateUrl: './number-of-orders.component.html',
  styleUrls: ['./number-of-orders.component.css'],
  encapsulation: ViewEncapsulation.None,
})
export class NumberOfOrdersComponent implements OnInit {

  clients : ClientsID[];

  orders : Ordersdet[];

  keyword = 'name';

  pickerS : string = "";

  pickerE : string = "";

  idClient: number = 0;

  totalOrders: number = -1;

  port : string = "";

  dateClass: MatCalendarCellClassFunction<Date> = (cellDate, view) => {
    // Only highligh dates inside the month view.
    if (view === 'month') {
      const date = cellDate.getDate();
      // Highlight the 1st and 20th day of each month.
      return (date === 1 || date === 20) ? 'example-custom-date-class' : '';
    }

    return '';
  }

  constructor(private http: HttpClient) { 
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
    this.http.get<ClientsID[]>('https://localhost:' + this.port  + '/' + 'ordersbyclient').subscribe(result => {
      this.clients = result;
    }, error => console.error(error));

    
  }

  ngOnInit(): void {

  }

  selectEvent(item) {
    this.idClient = item.idClient;
  }
 
  onChangeSearch(val: string) {
    // fetch remote data from here
    // And reassign the 'data' which is binded to 'data' property.
  }
  
  onFocused(e){
    // do something when input is focused
  }

  getTotal(event){
    this.http.post('https://localhost:' + this.port  + '/' + 'ordersbyclient', {dateS: this.pickerS, dateE: this.pickerE, idClient : this.idClient, totalOrders: this.totalOrders, orders: []}).subscribe(
      res=> {
        console.log(res);
        this.totalOrders = res["totalOrders"];
        this.orders = res["orders"];
      }
    )
  }

}
