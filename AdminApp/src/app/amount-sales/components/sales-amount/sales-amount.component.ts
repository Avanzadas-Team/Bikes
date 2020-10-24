import { Identifiers } from '@angular/compiler';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { tick } from '@angular/core/testing';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-sales-amount',
  templateUrl: './sales-amount.component.html',
  styleUrls: ['./sales-amount.component.css']
})
export class SalesAmountComponent implements OnInit, OnDestroy {
  private sub: any;
  store: string;

  constructor(private route: ActivatedRoute) { }



  ngOnInit(): void {
    this.sub = this.route.params.subscribe(params => {
      this.store = params['id'];
    });
  }

  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }
}
