import { RouterModule } from '@angular/router';
import { AmountSalesRountingModule } from './amount-sales-rounting.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SalesAmountHomePageComponent } from './components/sales-amount-home-page/sales-amount-home-page.component';
import { SalesAmountComponent } from './components/sales-amount/sales-amount.component';
import { NgbPaginationModule, NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ProdSalesComponent } from './components/prod-sales/prod-sales.component';
import { HttpClientModule } from '@angular/common/http';



@NgModule({
  declarations: [SalesAmountHomePageComponent, SalesAmountComponent, ProdSalesComponent],
  imports: [
    RouterModule,
    CommonModule,
    AmountSalesRountingModule,
    NgbPaginationModule,
    NgbModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  exports: [SalesAmountHomePageComponent, SalesAmountComponent],
})
export class AmountSalesModule { }
