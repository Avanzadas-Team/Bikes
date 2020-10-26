import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import OrdersByClientRoutes from './orders-by-client.routes';


@NgModule({
  imports: [
    RouterModule.forChild(OrdersByClientRoutes.routes)
  ],
  exports: [RouterModule]
})
export class OrdersByClientRoutingModule { }