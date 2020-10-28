import { ProdSalesComponent } from './components/prod-sales/prod-sales.component';
import { SalesAmountHomePageComponent } from './components/sales-amount-home-page/sales-amount-home-page.component';
import { Routes } from '@angular/router';
import { SalesAmountComponent } from './components/sales-amount/sales-amount.component';

export default class AmountSalesRoutes {
  static routes: Routes = [
    {
      path: '', children: [
        { path: '', component: SalesAmountHomePageComponent },
        { path: 'store/:id', component: SalesAmountComponent },
        { path: 'prod-sales', component: ProdSalesComponent }
      ]
    }
  ];
}
