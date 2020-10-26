import { StoresTotalSalesModule } from './stores-total-sales/stores-total-sales.module';
import { HomeComponent } from './shared/components/home/home.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { OrdersByClientModule } from './orders-by-client/orders-by-client.module';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'orders', loadChildren: () => OrdersByClientModule},
  { path: 'total', loadChildren: () => StoresTotalSalesModule}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
