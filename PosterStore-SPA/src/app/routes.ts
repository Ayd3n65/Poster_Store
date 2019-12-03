import {Routes} from '@angular/router';
import { HomeComponent } from './home/home.component';
import { PosterListComponent } from './posters/poster-list/poster-list.component';
import { PosterDetailComponent } from './posters/poster-detail/poster-detail.component';
import { PosterDetailResolver } from './_resolvers/poster-detail.resolver';
import { PosterCreateComponent } from './posters/poster-create/poster-create.component';

export const appRoutes: Routes = [
  {path: 'home', component: HomeComponent},
  {path: 'posters', component: PosterListComponent},
  {path: 'posters/:id', component: PosterDetailComponent},
  {path: 'createPoster', component: PosterCreateComponent}

  // {path: '**', redirectTo: 'home', pathMatch: 'full '}
];
