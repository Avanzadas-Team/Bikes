import { SalesProdCatgComponent } from './components/sales-prod-catg/sales-prod-catg.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: 'SalesByProd', component: SalesProdCatgComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SalesAmountRoutingModule { }
