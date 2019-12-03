import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { PosterService } from '../_services/poster.service';
import { Poster } from '../_models/poster';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { AlertifyService } from '../_services/alertify.service';

@Injectable()
export class PosterDetailResolver implements Resolve<Poster> {
    constructor(private posterService: PosterService, private router: Router, private alerify: AlertifyService) { }
    resolve(route: ActivatedRouteSnapshot):  Observable<Poster> {
      return this.posterService.getPoster(route.params['id']).pipe(
        catchError(error => {
          this.alerify.error('Проблемы с получением данных');
          this.router.navigate(['/posters']);
          return of(null);
        })
      );
        // Когда мы используем resolver мы выходим из posterService ->
        // получаем poster, который совпадает c route parametr(там наша id), который мы стремимся получить ->
        // все остально это ловим ошибки
    }
}
