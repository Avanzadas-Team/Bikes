import { StoresTotalSalesModule } from './stores-total-sales/stores-total-sales.module';
import { OrdersByClientModule } from './orders-by-client/orders-by-client.module';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SharedModule } from './shared/shared.module';
import { HttpClientModule } from '@angular/common/http';
import { ClientPurchasesModule } from './client-purchases/client-purchases.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AuthModule } from './auth/auth.module';
import { RouterModule } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AutocompleteLibModule } from 'angular-ng-autocomplete';


@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    SharedModule,
    AuthModule,
    ClientPurchasesModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule,
    OrdersByClientModule,
    BrowserAnimationsModule,
    AutocompleteLibModule,
    StoresTotalSalesModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
