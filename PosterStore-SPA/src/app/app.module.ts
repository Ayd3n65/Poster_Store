import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpClientModule} from '@angular/common/http';
import {FormsModule} from '@angular/forms';
import { BsDropdownModule } from 'ngx-bootstrap';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { ValueComponent } from './value/value.component';
import { NavComponent } from './nav/nav.component';
import { PosterListComponent } from './posters/poster-list/poster-list.component';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';

import { HttpClient } from 'selenium-webdriver/http';

import {AccountService} from './_services/account.service';
import { from } from 'rxjs';
import { ErrorInterceptor, ErrorInterceptorProvider } from './_services/error.interceptor';
import { AlertifyService } from './_services/alertify.service';
import { appRoutes } from './routes';
import { PosterService } from './_services/poster.service';
import { PosterCardComponent } from './posters/poster-card/poster-card.component';

@NgModule({
   declarations: [
      AppComponent,
      ValueComponent,
      NavComponent,
      HomeComponent,
      RegisterComponent,
      PosterListComponent,
      PosterCardComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule,
      BsDropdownModule.forRoot(),
      RouterModule.forRoot(appRoutes)
   ],
   providers: [
      AccountService,
      ErrorInterceptorProvider,
      AlertifyService,
      PosterService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
