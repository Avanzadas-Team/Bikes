import { Routes } from '@angular/router';
import { CreateClientComponent } from './components/create-client/create-client.component';

export default class CreateClientRoutes {
  static routes: Routes = [
    {
      path: '', children: [
        {path: 'Create-client', component: CreateClientComponent}
      ]
    }
  ];
}
