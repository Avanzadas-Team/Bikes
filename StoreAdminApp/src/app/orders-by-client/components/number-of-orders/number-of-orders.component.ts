import { ClientsID } from './../../models/ClientsID';
import { Component, OnInit, Inject, ViewEncapsulation} from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {MatCalendarCellClassFunction} from '@angular/material/datepicker';




@Component({
  selector: 'app-number-of-orders',
  templateUrl: './number-of-orders.component.html',
  styleUrls: ['./number-of-orders.component.css'],
  encapsulation: ViewEncapsulation.None,
})
export class NumberOfOrdersComponent implements OnInit {

  clients : ClientsID[];

  keyword = 'name';

  pickerS : string = "";

  pickerE : string = "";

  idClient: number = 0;

  totalOrders: number = -1;

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
    this.http.get<ClientsID[]>('https://localhost:5001/' + 'ordersbyclient').subscribe(result => {
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
    this.http.post('https://localhost:5001/' + 'ordersbyclient', {dateS: this.pickerS, dateE: this.pickerE, idClient : this.idClient, totalOrders: this.totalOrders}).subscribe(
      res=> {
        console.log(res);
        this.totalOrders = res["totalOrders"];
      }
    )
  }

}
