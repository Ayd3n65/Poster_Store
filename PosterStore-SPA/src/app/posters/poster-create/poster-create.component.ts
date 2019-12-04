import { Component, OnInit } from '@angular/core';
import { Poster } from 'src/app/_models/poster';
import { PosterToCreate } from 'src/app/_models/posterToCreate';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-poster-create',
  templateUrl: './poster-create.component.html',
  styleUrls: ['./poster-create.component.css']
})
export class PosterCreateComponent implements OnInit {
  public poster: PosterToCreate;
  public isCreate: boolean;
  public title: string;
  public description: string;
  public price: string;
  public size: string;
  public photoUrl: string;
  public response: {'dbPath': ''};
  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.isCreate = true;
  }
  public onCreate = () => {
    this.poster = {
      title: this.title,
      price: this.price,
      photoUrl: this.response.dbPath,
      description: this.description,
      size: this.size
    };
    this.http.post('https://localhost:5000/api/posters', this.poster)
    .subscribe(res => {
      this.isCreate = false;
    });
  }

}
