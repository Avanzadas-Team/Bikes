import { CreateSellComponent } from './components/create-sell/create-sell.component';
import { Routes } from '@angular/router';

export default class CreateSellRoutes {
  static routes: Routes = [
    {
      path: '', children: [
        {path: 'Create-sell', component: CreateSellComponent}
      ]
    }
  ];
}
