import {Routes} from '@angular/router';
import { HomeComponent } from './home/home.component';
import { PosterListComponent } from './posters/poster-list/poster-list.component';

export const appRoutes: Routes = [
  {path: 'home', component: HomeComponent},
  {path: 'posters', component: PosterListComponent},
  // {path: '**', redirectTo: 'home', pathMatch: 'full '}
];
