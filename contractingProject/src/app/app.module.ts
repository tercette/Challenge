import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './auth/pages/login/login.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NewsComponent } from './auth/pages/news/news.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { Interceptor } from './interceptor/interceptor';
import { MovimentationComponent } from './auth/pages/movimentation/movimentation.component';
import { MatInputModule } from '@angular/material/input';
import { MatRadioModule } from '@angular/material/radio';
import { FormsModule } from '@angular/forms';
import { CurrencyMaskModule } from "ng2-currency-mask";

const authService = [Interceptor]

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    NewsComponent,
    NavbarComponent,
    MovimentationComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatButtonModule,
    MatIconModule,
    ReactiveFormsModule,
    CommonModule,
    HttpClientModule,
    MatInputModule,
    FormsModule,
    MatRadioModule,
    CurrencyMaskModule
  ],
  providers: [
    authService,
    { provide : HTTP_INTERCEPTORS, useClass:Interceptor, multi: true }
  ],

  bootstrap: [AppComponent]
})
export class AppModule { }
