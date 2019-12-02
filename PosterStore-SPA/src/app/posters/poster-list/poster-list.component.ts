import { Component, OnInit } from '@angular/core';
import { Poster } from '../../_models/poster';
import { PosterService } from '../../_services/poster.service';

@Component({
  selector: 'app-poster-list',
  templateUrl: './poster-list.component.html',
  styleUrls: ['./poster-list.component.css']
})
export class PosterListComponent implements OnInit {
  posters: Poster[];
  constructor(private posterService: PosterService) { }

  ngOnInit() {
    this.loadPosters();
  }
  loadPosters() {
    this.posterService.getPosters().subscribe((posters: Poster[]) => {
      this.posters = posters;
    }, error => {
      console.log(error);
    });
  }

}
