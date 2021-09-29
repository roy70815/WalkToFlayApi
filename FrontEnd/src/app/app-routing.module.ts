import { RouterManageComponent } from './components/router-manage/router-manage.component';
import { EcashListComponent } from './components/ecash-list/ecash-list.component';
import { StoreListComponent } from './components/store-list/store-list.component';
import { ProductListComponent } from './components/product-list/product-list.component';
import { OrderListComponent } from './components/order-list/order-list.component';
import { BasicLayoutComponent } from './layout/basic-layout/basic-layout.component';
import { LoginComponent } from './components/login/login.component';
import { HomeComponent } from './components/home/home.component';
import { NgModule, Component } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MemberListComponent } from './components/member-list/member-list.component';
import { AuthGuard } from './services/auth-guard.service';
import { RouterListComponent } from './components/router-manage/router-list/router-list.component';
import { RouterDetailComponent } from './components/router-manage/router-detail/router-detail.component';

const routes: Routes = [
  { path: 'home', component: BasicLayoutComponent, canActivate: [AuthGuard], data: { Component: HomeComponent } },
  { path: 'order/list', component: BasicLayoutComponent, canActivate: [AuthGuard], data: { Component: OrderListComponent } },
  { path: 'member/list', component: BasicLayoutComponent, canActivate: [AuthGuard], data: { Component: MemberListComponent } },
  { path: 'product/list', component: BasicLayoutComponent, canActivate: [AuthGuard], data: { Component: ProductListComponent } },
  { path: 'store/list', component: BasicLayoutComponent, canActivate: [AuthGuard], data: { Component: StoreListComponent } },
  { path: 'ecash/list', component: BasicLayoutComponent, canActivate: [AuthGuard], data: { Component: EcashListComponent } },


  { path: 'router', component: BasicLayoutComponent, canActivate: [AuthGuard], data: { Component: RouterManageComponent } ,
    children:[
      {path:'list',component:RouterListComponent},
      {path:'add',component:RouterDetailComponent},
      {path:'detail/:id',component:RouterDetailComponent}
    ]
  },


  { path: 'login', component: LoginComponent },
  { path: '**', redirectTo: 'home' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
