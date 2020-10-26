import { RouterModule } from '@angular/router';
import { AmountSalesModule } from './amount-sales/amount-sales.module';
import { NavMenuComponent } from './core/components/nav-menu/nav-menu.component';
import { HttpClientModule } from '@angular/common/http';
import { ClientBoughtsModule } from './client-boughts/client-boughts.module';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { StoresTotalSalesModule } from './stores-total-sales/stores-total-sales.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { OrdersByClientModule } from './orders-by-client/orders-by-client.module';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { MatDatepickerModule } from '@angular/material/datepicker';
import { AutocompleteLibModule } from 'angular-ng-autocomplete';
import { MatNativeDateModule } from '@angular/material/core';
import { MatButtonModule } from '@angular/material/button';
import {FormsModule} from '@angular/forms';
@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent
  ],
  imports: [
    RouterModule,
    HttpClientModule,
    BrowserModule,
    ClientBoughtsModule,
    StoresTotalSalesModule,
    OrdersByClientModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    AutocompleteLibModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatButtonModule,
    FormsModule,
    AmountSalesModule,
    AppRoutingModule,
    NgbModule
  ],
  providers: [
    MatDatepickerModule,
    MatNativeDateModule
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
