import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { HomepageComponent } from './components/homepage/homepage.component';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [NavMenuComponent, HomepageComponent],
  imports: [
    RouterModule,
    CommonModule
  ]
})
export class CoreModule { }
