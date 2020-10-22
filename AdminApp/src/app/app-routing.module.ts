import { HomepageComponent } from './core/components/homepage/homepage.component';
import { ClientBoughtsModule } from './client-boughts/client-boughts.module';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: '', component: HomepageComponent},
  { path: 'clients', loadChildren: () => ClientBoughtsModule}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
