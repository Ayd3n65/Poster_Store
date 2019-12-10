import {Routes} from '@angular/router';
import { HomeComponent } from './home/home.component';
import { PosterListComponent } from './posters/poster-list/poster-list.component';
import { PosterDetailComponent } from './posters/poster-detail/poster-detail.component';
import { PosterCreateComponent } from './posters/poster-create/poster-create.component';
import { AdminPanelComponent } from './admin/admin-panel/admin-panel.component';
import { AuthGuard } from './_guards/auth.guard';
import { PosterListResolver } from './_resolvers/poster-list.resolver';
import { PosterDetailResolver } from './_resolvers/poster-detail.resolver';

export const appRoutes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'createPoster', component: PosterCreateComponent},
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
  {path: 'admin', component: AdminPanelComponent, data: {roles: ['Admin', 'Moderator']}},
  {path: 'posters', component: PosterListComponent, resolve: {posters: PosterListResolver}},
  {path: 'posters/:id', component: PosterDetailComponent, resolve: {poster: PosterDetailResolver}},
  ],
  },
   {path: '**', redirectTo: 'home', pathMatch: 'prefix'}
];
