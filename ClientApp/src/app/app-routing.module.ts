import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UsersComponent } from './users/users.component';
import { DetailsComponent } from './details/details.component';
import { PostsComponent } from './posts/posts.component';
import { EmployeeSellModule } from './employee-sell/employee-sell.module';
//import {SidebarComponent } from './sidebar/sidebar.component';

const routes: Routes = [
  {
    path: 'sells', loadChildren: ()  => EmployeeSellModule 
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
