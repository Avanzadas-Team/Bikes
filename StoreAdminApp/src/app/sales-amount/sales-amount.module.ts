import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SalesAmountRoutingModule } from './sales-amount-routing.module';
import { SalesProdCatgComponent } from './components/sales-prod-catg/sales-prod-catg.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';


@NgModule({
  declarations: [SalesProdCatgComponent],
  imports: [
    CommonModule,
    SalesAmountRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  exports: [
    SalesProdCatgComponent
  ]
})
export class SalesAmountModule { }
