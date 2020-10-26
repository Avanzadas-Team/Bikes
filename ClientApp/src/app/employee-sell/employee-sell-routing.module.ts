import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import EmployeeSellRoutes from './employee-sell.routes';

@NgModule({
  imports: [
    RouterModule.forChild(EmployeeSellRoutes.routes)
  ],
  exports: [RouterModule]
})
export class EmployeeSellRoutingModule { }
