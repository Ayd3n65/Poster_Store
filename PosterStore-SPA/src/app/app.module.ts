import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpClientModule} from '@angular/common/http';
import {FormsModule} from '@angular/forms';
import { BsDropdownModule, TabsModule, PaginationModule } from 'ngx-bootstrap';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { ValueComponent } from './value/value.component';
import { NavComponent } from './nav/nav.component';
import { PosterListComponent } from './posters/poster-list/poster-list.component';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { PosterCardComponent } from './posters/poster-card/poster-card.component';
import { PosterDetailComponent } from './posters/poster-detail/poster-detail.component';

import { HttpClient } from 'selenium-webdriver/http';

import {AccountService} from './_services/account.service';
import { from } from 'rxjs';
import { ErrorInterceptor, ErrorInterceptorProvider } from './_services/error.interceptor';
import { AlertifyService } from './_services/alertify.service';
import { appRoutes } from './routes';
import { PosterService } from './_services/poster.service';
import { PosterDetailResolver } from './_resolvers/poster-detail.resolver';
import { PosterCreateComponent } from './posters/poster-create/poster-create.component';
import { UploadComponent } from './posters/poster-create/upload/upload.component';
import { AdminPanelComponent } from './admin/admin-panel/admin-panel.component';
import { JwtHelperService } from '@auth0/angular-jwt';
import { AuthGuard } from './_guards/auth.guard';
import { HasRoleDirective } from './_directives/hasRole.directive';
import { AdminService } from './_services/admin.service';
import { UserManagComponent } from './admin/user-manag/user-manag.component';
import { PosterListResolver } from './_resolvers/poster-list.resolver';

@NgModule({
   declarations: [
      AppComponent,
      ValueComponent,
      NavComponent,
      HomeComponent,
      RegisterComponent,
      PosterListComponent,
      PosterCardComponent,
      PosterDetailComponent,
      PosterCreateComponent,
      UploadComponent,
      AdminPanelComponent,
      HasRoleDirective,
      UserManagComponent

   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule,
      BsDropdownModule.forRoot(),
      RouterModule.forRoot(appRoutes),
      TabsModule.forRoot(),
      PaginationModule.forRoot()
   ],
   providers: [
      AccountService,
      ErrorInterceptorProvider,
      AlertifyService,
      PosterService,
      PosterDetailResolver,
      JwtHelperService,
      AuthGuard,
      AdminService,
      PosterListResolver
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
