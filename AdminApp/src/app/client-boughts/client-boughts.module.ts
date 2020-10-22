import { ClientBoughtsRoutingModule } from './client-boughts-routing.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BestClientsComponent } from './components/best-clients/best-clients.component';



@NgModule({
  declarations: [BestClientsComponent],
  imports: [
    CommonModule,
    ClientBoughtsRoutingModule
  ],
  exports: [BestClientsComponent]
})
export class ClientBoughtsModule { }
