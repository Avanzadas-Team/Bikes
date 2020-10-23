import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import StoreTotalSalesRoutes from './store-total-sales.routes';


@NgModule({
  imports: [
    RouterModule.forChild(StoreTotalSalesRoutes.routes)
  ],
  exports: [RouterModule]
})
export class StoresTotalSalesRoutingModule { }