import { Order } from './../../models/order';
import { Identifiers } from '@angular/compiler';
import { Component, OnDestroy, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-sales-amount',
  templateUrl: './sales-amount.component.html',
  styleUrls: ['./sales-amount.component.css'],
})
export class SalesAmountComponent implements OnInit, OnDestroy {
  private sub: any;
  compOrders: Order[];
  filtOrders: Order[];
  orders: Order[];
  page = 1;
  pageSize = 8;
  collectionSize: number;

  constructor(
    private readonly http: HttpClient,
    @Inject('BASE_URL') private readonly baseUrl: string,
    private readonly route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.sub = this.route.params.subscribe((params) => {
      let store: string = params['id'];
      this.http.get<Order[]>(this.baseUrl + 'salesamount/' + store).subscribe(
        (result) => {
          this.collectionSize = result.length;
          this.compOrders = result;
          this.filtOrders = result;
          this.refresh();
        },
        (error) => console.error(error)
      );
    });
  }

  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }

  refresh() {
    this.orders = this.filtOrders
      .map((country, i) => ({id: i + 1, ...country}))
      .slice((this.page - 1) * this.pageSize, (this.page - 1) * this.pageSize + this.pageSize);
  }

  calculateAmount(): number
  {
    let value = 0;
    this.filtOrders.forEach(
      order => value += order.precioVenta
    )
    return value;
  }
}
