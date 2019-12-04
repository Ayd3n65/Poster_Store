import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Poster } from '../_models/poster';
import { HttpClient, HttpHeaders } from '@angular/common/http';

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
getPosters(): Observable<Poster[]> {
  return this.http.get<Poster[]>(this.baseUrl + 'posters', httpOptions);
}
getPoster(id): Observable<Poster> {
  return this.http.get<Poster>(this.baseUrl + 'posters/' + id, httpOptions);
}
registerPoster(model: any) {
  return this.http.post(this.baseUrl + 'poster/registerPoster', model);
}
upload(formData) {
  return this.http.request('https://localhost:5000/api/posters', formData, {reportProgress: true, observe: 'events'});
}


}
