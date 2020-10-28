import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreateClientComponent } from './components/create-client/create-client.component';
import { AutocompleteLibModule } from 'angular-ng-autocomplete';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatButtonModule } from '@angular/material/button';
import { FormsModule } from '@angular/forms';
import { CreateClientRoutingModule } from './create-sell-routing.module';



@NgModule({
  declarations: [CreateClientComponent],
  imports: [
    CommonModule,
    CreateClientRoutingModule,
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
  exports: [CreateClientComponent]
})
export class CreateClientModule { }
