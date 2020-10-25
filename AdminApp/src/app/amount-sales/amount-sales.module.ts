import { RouterModule } from '@angular/router';
import { AmountSalesRountingModule } from './amount-sales-rounting.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SalesAmountHomePageComponent } from './components/sales-amount-home-page/sales-amount-home-page.component';
import { SalesAmountComponent } from './components/sales-amount/sales-amount.component';
import { NgbPaginationModule, NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [SalesAmountHomePageComponent, SalesAmountComponent],
  imports: [
    RouterModule,
    CommonModule,
    AmountSalesRountingModule,
    NgbPaginationModule,
    NgbModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  exports: [SalesAmountHomePageComponent, SalesAmountComponent],
})
export class AmountSalesModule { }
