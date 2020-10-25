import { AuthModule } from './../auth/auth.module';
import { RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { HomeComponent } from './components/home/home.component';



@NgModule({
  declarations: [NavMenuComponent, HomeComponent],
  imports: [
    CommonModule,
    RouterModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    AuthModule
  ],
  exports: [
    NavMenuComponent,
    HomeComponent
  ]
})
export class SharedModule { }
