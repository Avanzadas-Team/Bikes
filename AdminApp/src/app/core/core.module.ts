import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { HomepageComponent } from './components/homepage/homepage.component';



@NgModule({
  declarations: [NavMenuComponent, HomepageComponent],
  imports: [
    CommonModule
  ]
})
export class CoreModule { }
