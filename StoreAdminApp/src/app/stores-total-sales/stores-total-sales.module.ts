import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TotalSalesComponent } from './components/total-sales/total-sales.component';
import { StoresTotalSalesRoutingModule } from './stores-total-sales-routing.module';



@NgModule({
  declarations: [TotalSalesComponent],
  imports: [
    CommonModule,
    StoresTotalSalesRoutingModule
  ],
  exports: [TotalSalesComponent]
})
export class StoresTotalSalesModule { }
