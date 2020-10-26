import { NgModule, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EmployeeSellRoutingModule } from './employee-sell-routing.module';
import { SellsComponent } from './components/sells/sells.component';


@NgModule({
  declarations: [SellsComponent],
  imports: [
    CommonModule,
    EmployeeSellRoutingModule
  ],
  exports: [SellsComponent]
})
export class EmployeeSellModule{ 

}
