import { CreateSellRoutingModule } from './create-sell-routing.module';
import { CreateSellComponent } from './components/create-sell/create-sell.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AutocompleteLibModule } from 'angular-ng-autocomplete';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatButtonModule } from '@angular/material/button';
import {FormsModule} from '@angular/forms';

@NgModule({
  declarations: [CreateSellComponent],
  imports: [
    CommonModule,
    CreateSellRoutingModule,
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
  exports: [CreateSellComponent]
})
export class CreateSellModule { }
