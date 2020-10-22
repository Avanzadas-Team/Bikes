import { BestClientsComponent } from './components/best-clients/best-clients.component';
import { Routes } from '@angular/router';

export default class ClientBoughtsRoutes {
  static routes: Routes = [
    {
      path: '', component: BestClientsComponent
    }
  ];
}
