import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import {RibComponent} from './rib/rib.component';


const routes: Routes = [

{path:'rib',component:RibComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
