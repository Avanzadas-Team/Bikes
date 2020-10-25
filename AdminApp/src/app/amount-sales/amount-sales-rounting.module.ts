import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import AmountSalesRoutes from './amount-sales.routes';

@NgModule({
  imports: [
    RouterModule.forChild(AmountSalesRoutes.routes)
  ],
  exports: [RouterModule]
})
export class AmountSalesRountingModule { }
