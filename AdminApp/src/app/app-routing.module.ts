import { HomepageComponent } from './core/components/homepage/homepage.component';
import { ClientBoughtsModule } from './client-boughts/client-boughts.module';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { StoresTotalSalesModule } from './stores-total-sales/stores-total-sales.module';
import { OrdersByClientModule } from './orders-by-client/orders-by-client.module';

const routes: Routes = [
  { path: '', component: HomepageComponent},
  { path: 'clients', loadChildren: () => ClientBoughtsModule},
  { path: 'total', loadChildren: () => StoresTotalSalesModule},
  { path: 'orders', loadChildren: () => OrdersByClientModule}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
