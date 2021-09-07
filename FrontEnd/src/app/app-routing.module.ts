import { EcashListComponent } from './components/ecash-list/ecash-list.component';
import { StoreListComponent } from './components/store-list/store-list.component';
import { ProductListComponent } from './components/product-list/product-list.component';
import { OrderListComponent } from './components/order-list/order-list.component';
import { BasicLayoutComponent } from './layout/basic-layout/basic-layout.component';
import { LoginComponent } from './components/login/login.component';
import { HomeComponent } from './components/home/home.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MemberListComponent } from './components/member-list/member-list.component';

const routes: Routes = [
  { path: 'home', component: BasicLayoutComponent,children:[{path:'',component:HomeComponent}] },
  { path: 'order/list', component: BasicLayoutComponent,children:[{path:'',component:OrderListComponent}] },
  { path: 'member/list', component: BasicLayoutComponent,children:[{path:'',component:MemberListComponent}] },
  { path: 'product/list', component: BasicLayoutComponent,children:[{path:'',component:ProductListComponent}] },
  { path: 'store/list', component: BasicLayoutComponent,children:[{path:'',component:StoreListComponent}] },
  { path: 'ecash/list', component: BasicLayoutComponent,children:[{path:'',component:EcashListComponent}] },
  { path: 'login', component: LoginComponent },
  { path: '**', redirectTo:'home' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
