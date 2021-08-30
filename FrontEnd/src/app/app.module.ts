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
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    LoginComponent,
    BasicLayoutComponent,
    RegisterComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    NgbModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

// imports: [BrowserModule, FormsModule, NgbModule],
// declarations: [NgbdDatepickerPopup],
// exports: [NgbdDatepickerPopup],
// bootstrap: [NgbdDatepickerPopup]
// })
