import { SellsComponent } from './components/sells/sells.component';
import { Routes } from '@angular/router';

export default class ClientBoughtsRoutes {
  static routes: Routes = [
    {
      path: '', children: [
        {path: 'create', component: SellsComponent}
      ]
    }
  ];
}
