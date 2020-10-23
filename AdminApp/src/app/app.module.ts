import { NavMenuComponent } from './core/components/nav-menu/nav-menu.component';
import { HttpClientModule } from '@angular/common/http';
import { ClientBoughtsModule } from './client-boughts/client-boughts.module';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { StoresTotalSalesModule } from './stores-total-sales/stores-total-sales.module';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    ClientBoughtsModule,
    StoresTotalSalesModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
