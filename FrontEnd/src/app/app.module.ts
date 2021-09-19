import { SystemFunctionService } from './services/system-function.service';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { NgbDatepicker, NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { BasicLayoutComponent } from './layout/basic-layout/basic-layout.component';
import { RegisterComponent } from './components/register/register.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { MenuComponent } from './components/menu/menu.component';
import { MemberListComponent } from './components/member-list/member-list.component';
import { ProductListComponent } from './components/product-list/product-list.component';
import { OrderListComponent } from './components/order-list/order-list.component';
import { StoreListComponent } from './components/store-list/store-list.component';
import { EcashListComponent } from './components/ecash-list/ecash-list.component';
import { AppHttpInterceptorService } from './services/app-http-interceptor.service';
import { AgGridModule } from 'ag-grid-angular';
@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    LoginComponent,
    BasicLayoutComponent,
    RegisterComponent,
    MenuComponent,
    MemberListComponent,
    ProductListComponent,
    OrderListComponent,
    StoreListComponent,
    EcashListComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    NgbModule,
    HttpClientModule,
    ReactiveFormsModule,
    AgGridModule
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AppHttpInterceptorService,
      multi: true,
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

// imports: [BrowserModule, FormsModule, NgbModule],
// declarations: [NgbdDatepickerPopup],
// exports: [NgbdDatepickerPopup],
// bootstrap: [NgbdDatepickerPopup]
// })
