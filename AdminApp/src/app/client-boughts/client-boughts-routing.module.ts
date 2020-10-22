import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import ClientBoughtsRoutes from './client-boughts.routes';
@NgModule({
  imports: [
    RouterModule.forChild(ClientBoughtsRoutes.routes)
  ],
  exports: [RouterModule]
})
export class ClientBoughtsRoutingModule { }