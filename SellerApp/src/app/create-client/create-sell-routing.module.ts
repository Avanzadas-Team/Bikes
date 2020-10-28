import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import CreateClientRoutes from './create-sell.routes';


@NgModule({
  imports: [
    RouterModule.forChild(CreateClientRoutes.routes)
  ],
  exports: [RouterModule]
})
export class CreateClientRoutingModule { }