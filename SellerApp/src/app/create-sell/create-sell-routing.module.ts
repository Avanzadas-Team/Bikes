import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import CreateSellRoutes from './create-sell.routes';


@NgModule({
  imports: [
    RouterModule.forChild(CreateSellRoutes.routes)
  ],
  exports: [RouterModule]
})
export class CreateSellRoutingModule { }