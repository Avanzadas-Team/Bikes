import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ClientPurchasesRoutingModule } from './client-purchases-routing.module';
import { ClientAverageComponent } from './components/client-average/client-average.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';


@NgModule({
  declarations: [ClientAverageComponent],
  imports: [
    CommonModule,
    ClientPurchasesRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  exports: [
    ClientAverageComponent
  ]
})
export class ClientPurchasesModule { }
