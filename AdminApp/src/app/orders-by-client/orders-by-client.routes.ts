import { NumberOfOrdersComponent } from './components/number-of-orders/number-of-orders.component';
import { Routes } from '@angular/router';

export default class OrdersByClientRoutes {
  static routes: Routes = [
    {
      path: '', children: [
        {path: 'total', component: NumberOfOrdersComponent}
      ]
    }
  ];
}
