import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Poster } from '../_models/poster';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { PaginatedResult } from '../_models/pagination';
import { map } from 'rxjs/operators';


const httpOptions = {
  headers: new HttpHeaders({
    'Authorization': 'Bearer ' + localStorage.getItem('token')
  })
};
@Injectable({
  providedIn: 'root'
})

export class PosterService {
baseUrl = 'http://localhost:5000/api/';

constructor(private http: HttpClient) { }

  getPosters(page?, itemsPerPage?): Observable<PaginatedResult<Poster[]>> {
  const paginatedResult: PaginatedResult<Poster[]> = new PaginatedResult<Poster[]>();

  let params  = new HttpParams();

  if (page != null && itemsPerPage != null) {
    params =  params.append('pageNumber', page);
    params = params.append('pageSize', itemsPerPage);
  }
  return this.http.get<Poster[]>(this.baseUrl + 'posters', {observe: 'response', params })
    .pipe(
      map(response => {
        paginatedResult.result = response.body;
        if (response.headers.get('Pagination') != null) {
          paginatedResult.pagination = JSON.parse(response.headers.get('Pagination'));
        }
          return paginatedResult;
      })
    );
}
getPoster(id): Observable<Poster> {
  return this.http.get<Poster>(this.baseUrl + 'posters/' + id);
}
registerPoster(model: any) {
  return this.http.post(this.baseUrl + 'poster/registerPoster', model);
}
upload(formData) {
  return this.http.request('https://localhost:5000/api/posters', formData, {reportProgress: true, observe: 'events'});
}


}
