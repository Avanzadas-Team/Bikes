import { ClientAverageComponent } from './components/client-average/client-average.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: 'Clients-Average', component: ClientAverageComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ClientPurchasesRoutingModule { }
