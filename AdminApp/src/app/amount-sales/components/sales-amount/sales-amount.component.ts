import { Order } from './../../models/order';
import { Component, OnDestroy, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';
import {
  NgbDate,
  NgbCalendar,
  NgbDateParserFormatter,
} from '@ng-bootstrap/ng-bootstrap';

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
  startingDate: Date;
  endingDate: Date;
  hoveredDate: NgbDate | null = null;

  constructor(
    private readonly http: HttpClient,
    @Inject('BASE_URL') private readonly baseUrl: string,
    private readonly route: ActivatedRoute,
    private readonly calendar: NgbCalendar,
    public readonly formatter: NgbDateParserFormatter
  ) {
    this.startingDate = this.toDate(calendar.getToday());
    this.endingDate = this.toDate(calendar.getNext(calendar.getToday(), 'd', 10));
  }

  ngOnInit(): void {
    this.sub = this.route.params.subscribe((params) => {
      let store: string = params['id'];
      this.http.get<Order[]>(this.baseUrl + 'sa/' + store).subscribe(
        (result) => {
          result.forEach((val) => {
            this.setStartingDate(new Date(val.fechaOrden.toString()));
            this.setEndingDate(new Date(val.fechaOrden));
          });
          this.compOrders = result;
          this.filter();
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
      .map((country, i) => ({ id: i + 1, ...country }))
      .slice(
        (this.page - 1) * this.pageSize,
        (this.page - 1) * this.pageSize + this.pageSize
      );
  }

  calculateAmount(): number {
    let value = 0;
    this.filtOrders.forEach((order) => (value += order.precioVenta));
    return value;
  }

  setStartingDate(date: Date): void {
    if (!this.startingDate || date < this.startingDate) this.startingDate = date;
  }

  setEndingDate(date: Date): void {
    if (!this.endingDate || date > this.endingDate) this.endingDate = date;
  }

  onDateSelection(date: NgbDate) {
    if (!this.startingDate && !this.endingDate) {
      this.startingDate = this.toDate(date);
    } else if (
      this.startingDate &&
      !this.endingDate &&
      date.after(this.toNgbDate(this.startingDate))
    ) {
      this.endingDate = this.toDate(date);
    } else {
      this.endingDate = null;
      this.startingDate = this.toDate(date);
    }
    this.filter();
  }

  isHovered(date: NgbDate) {
    return (
      this.startingDate &&
      !this.endingDate &&
      this.hoveredDate &&
      date.after(this.toNgbDate(this.startingDate)) &&
      date.before(this.hoveredDate)
    );
  }

  isInside(date: NgbDate) {
    return (
      this.endingDate &&
      date.after(this.toNgbDate(this.startingDate)) &&
      date.before(this.toNgbDate(this.endingDate))
    );
  }

  isRange(date: NgbDate) {
    return (
      date.equals(this.toNgbDate(this.startingDate)) ||
      (this.endingDate && date.equals(this.toNgbDate(this.endingDate))) ||
      this.isInside(date) ||
      this.isHovered(date)
    );
  }

  toDate(ngbDate: NgbDate): Date {
    if (!ngbDate)
      return null;
    return new Date(ngbDate.year, ngbDate.month - 1, ngbDate.day);
  }

  toNgbDate(date: Date): NgbDate {
    if (!date)
      return null;
    return new NgbDate(date.getFullYear(), date.getMonth() + 1, date.getDay());
  }

  filter() {
    this.filtOrders = this.compOrders.filter((order) => {
      return (
        new Date(order.fechaOrden) >= this.startingDate &&
        new Date(order.fechaOrden) <= this.endingDate
      );
    });
    this.collectionSize = this.filtOrders.length;
    this.refresh();
  }

  validateInput(currentValue: NgbDate | null, input: string): NgbDate | null {
    const parsed = this.formatter.parse(input);
    return parsed && this.calendar.isValid(NgbDate.from(parsed))
      ? NgbDate.from(parsed)
      : currentValue;
  }
}
