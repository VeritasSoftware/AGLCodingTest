import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AglPetsComponent } from './components/agl-pets/agl-pets.component'

const routes: Routes = [
  { 
    path: '',
    redirectTo: '/home',
    pathMatch: 'full'
  },  
  { 
    path: 'home', 
    component: AglPetsComponent 
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
