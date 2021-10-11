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
import { OrderListComponent } from './components/order-list/order-list.component';
import { StoreListComponent } from './components/store-list/store-list.component';
import { EcashListComponent } from './components/ecash-list/ecash-list.component';
import { AppHttpInterceptorService } from './services/app-http-interceptor.service';
import { AgGridModule } from 'ag-grid-angular';
import { RouterListComponent } from './components/router-manage/router-list/router-list.component';
import { TemplateRendererComponent } from './components/common/ag-grid/template-renderer/template-renderer.component';
import { TabComponent } from './components/common/tab/tab.component';
import { RouterDetailComponent } from './components/router-manage/router-detail/router-detail.component';
import { RouterManageComponent } from './components/router-manage/router-manage.component';
import { PageDirective } from './directive/page.directive';
import { ProductListComponent } from './components/product-manage/product-list/product-list.component';
import { ProductDetailComponent } from './components/product-manage/product-detail/product-detail.component';
import { ProductManageComponent } from './components/product-manage/product-manage.component';
@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    LoginComponent,
    BasicLayoutComponent,
    RegisterComponent,
    MenuComponent,
    MemberListComponent,
    OrderListComponent,
    StoreListComponent,
    EcashListComponent,
    RouterListComponent,
    TemplateRendererComponent,
    TabComponent,
    RouterDetailComponent,
    RouterManageComponent,
    PageDirective,
    ProductListComponent,
    ProductDetailComponent,
    ProductManageComponent,
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
