import { OrdersByClientRoutingModule } from './orders-by-client-routing.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NumberOfOrdersComponent } from './components/number-of-orders/number-of-orders.component';
import { AutocompleteLibModule } from 'angular-ng-autocomplete';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatButtonModule } from '@angular/material/button';
import {FormsModule} from '@angular/forms';




@NgModule({
  declarations: [NumberOfOrdersComponent],
  imports: [
    CommonModule,
    OrdersByClientRoutingModule,
    AutocompleteLibModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatButtonModule,
    FormsModule
  ],
  providers: [
    MatDatepickerModule,
    MatNativeDateModule
  ],
  exports: [NumberOfOrdersComponent]
})
export class OrdersByClientModule { }
