import { BestClientsComponent } from './best-clients/best-clients.component';
import { Routes } from '@angular/router';

export default class ClientBoughtsRoutes {
    static routes: Routes = [
      {
        path: '', children: [
          { path: 'best', component: BestClientsComponent},
        ]
      }
    ];
  }