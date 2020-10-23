import { TotalSalesComponent } from './components/total-sales/total-sales.component';
import { Routes } from '@angular/router';

export default class StoreTotalSalesRoutes {
  static routes: Routes = [
    {
      path: '', children: [
        {path: 'sales', component: TotalSalesComponent}
      ]
    }
  ];
}
