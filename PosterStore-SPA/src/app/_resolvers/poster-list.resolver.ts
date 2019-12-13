import {Injectable} from '@angular/core';
import {Resolve, Router, ActivatedRouteSnapshot} from '@angular/router';
import { AlertifyService } from '../_services/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { PosterService } from '../_services/poster.service';
import { Poster } from '../_models/poster';

@Injectable()
export class PosterListResolver implements Resolve<Poster[]> {
    pageNumber = 1;
    pageSize = 3;

    constructor(private posterService: PosterService, private router: Router,
        private alertify: AlertifyService) {}

    resolve(route: ActivatedRouteSnapshot): Observable<Poster[]> {
        return this.posterService.getPosters(this.pageNumber, this.pageSize).pipe(
            catchError(error => {
                this.alertify.error('Problem retrieving data');
                this.router.navigate(['/home']);
                return of(null);
            })
        );
    }
}
