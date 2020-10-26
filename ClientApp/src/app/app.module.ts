import { SellsComponent } from './employee-sell/components/sells/sells.component';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { HttpClientModule } from '@angular/common/http';
import { ServicesComponent } from './services/services.component';
import { EmployeeSellModule } from './employee-sell/employee-sell.module';
import { NavMenuComponent } from './core/components/nav-menu/nav-menu.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    EmployeeSellModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
