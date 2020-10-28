import { SellersID } from './../../models/SellersID';
import { ClientsID } from './../../models/ClientsID';
import { ProducID } from './../../models/ProductID';
import { AuthService } from './../../../auth.service';
import { Component, OnInit, Inject, ViewEncapsulation} from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import {MatCalendarCellClassFunction} from '@angular/material/datepicker';

@Component({
  selector: 'app-create-sell',
  templateUrl: './create-sell.component.html',
  styleUrls: ['./create-sell.component.scss'],
  encapsulation: ViewEncapsulation.None,
})
export class CreateSellComponent implements OnInit {

  clients : ClientsID[];

  sellers : SellersID[];

  idOrden : number = 1615;

  

  products : ProducID[];

  quantity : number;

  keyword = 'name';

  pickerE : string = "";

  idClient: number = 0;

  idEmployee: number = 0;

  idProduct: number = 0;
  
  price : number = 0;

  discount : number = 0;

  create: number = -1;

  dateClass: MatCalendarCellClassFunction<Date> = (cellDate, view) => {
    if (view === 'month') {
      const date = cellDate.getDate();
      return (date === 1 || date === 20) ? 'example-custom-date-class' : '';
    }

    return '';
  }

  constructor(private http: HttpClient,
    private auth: AuthService) { 

    this.http.get<ClientsID[]>('https://localhost:5001/' + 'ordersbyclient').subscribe(result => {
      this.clients = result;
    }, error => console.error(error));

    this.http.get<ProducID[]>('https://localhost:5001/' + 'product').subscribe(result => {
      this.products = result;
    }, error => console.error(error));

    if (this.auth.getStoreID() == '1') {
      this.http.get<SellersID[]>('https://localhost:5001/' + 'seller/NY').subscribe(result => {
        this.sellers = result;
      }, error => console.error(error));
    }

    else if (this.auth.getStoreID() == '2') {
      
      this.http.get<SellersID[]>('https://localhost:5001/' + 'seller/Cal').subscribe(result => {
        this.sellers = result;
      }, error => console.error(error));
    }

    else { 
      this.http.get<SellersID[]>('https://localhost:5001/' + 'seller/TX').subscribe(result => {
        this.sellers = result;
      }, error => console.error(error));
    }
  }

  ngOnInit(): void {
  }

  selectEvent(item) {
    this.idClient = item.idClient;
  }

  selectEventE(item) {
    this.idEmployee = item.idEmployee;
  }
  
  selectEventP(item) {
    this.idProduct = item.idProduct;
    this.price = item.price;
  }

  onChangeSearch(val: string) {
  }
  
  onFocused(e){
  }

  createSell(event){
    if (this.auth.getStoreID() == '1') {
      this.http.post('https://localhost:5001/' + 'seller/NY',{
         idCliente: this.idClient,
         fechaEnvio: this.pickerE, 
         idTienda: this.auth.getStoreID(), 
         idEmpleado: this.idEmployee, 
         idProducto: this.idProduct,
         cantidad: this.quantity, 
         precioVenta: this.price, 
         descuento: this.discount}).subscribe(
      res=> {
        console.log(res);
        this.create = res["create"];
      }
    )
    }else if (this.auth.getStoreID() == '2') {
      this.http.post('https://localhost:5001/' + 'seller/Cal',{
         idCliente: this.idClient,
         fechaEnvio: this.pickerE, 
         idTienda: this.auth.getStoreID(), 
         idEmpleado: this.idEmployee, 
         idProducto: this.idProduct,
         cantidad: this.quantity, 
         precioVenta: this.price, 
         descuento: this.discount}).subscribe(
      res=> {
        console.log(res);
        this.create = res["create"];
      })
    } else {
      this.http.post('https://localhost:5001/' + 'seller/TX',{
         idCliente: this.idClient,
         fechaEnvio: this.pickerE, 
         idTienda: this.auth.getStoreID(), 
         idEmpleado: this.idEmployee, 
         idProducto: this.idProduct,
         cantidad: this.quantity, 
         precioVenta: this.price, 
         descuento: this.discount}).subscribe(
      res=> {
        console.log(res);
        this.create = res["create"];
      }
    )
    }
  }


}
