import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './guards/auth.guard';
import {BaseLayoutComponent} from './shared/layouts/base-layout/base-layout.component';
const baseLayoutRouting: Routes = [
  {
    path: 'categories',
    loadChildren: () => import("./category/category.module").then(a=> a.CategoryModule),
   
  },
 
];

const routes: Routes = [
  {
    path: '',
    component: BaseLayoutComponent,
    children: baseLayoutRouting,
    canActivate:[AuthGuard]
  },
  {
    path: 'auth',
    loadChildren: () => import('./auth/auth.module').then(m => m.AuthModule)
  },
 
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
