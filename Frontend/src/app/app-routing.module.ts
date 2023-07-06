import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {HomePageComponent} from "./home-page/home-page.component";
import {ClientListComponent} from "./client/client-list/client-list.component";

const routes: Routes = [
  //хом
  {path: '', component: HomePageComponent},
  {path: 'client-list', component: ClientListComponent},
  //в конце
  {path: '**', component: HomePageComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
