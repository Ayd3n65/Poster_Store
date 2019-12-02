import { Component, OnInit, Input } from '@angular/core';
import { Poster } from 'src/app/_models/poster';

@Component({
  selector: 'app-poster-card',
  templateUrl: './poster-card.component.html',
  styleUrls: ['./poster-card.component.css']
})
export class PosterCardComponent implements OnInit {
  @Input() poster: Poster;
  constructor() { }

  ngOnInit() {
  }

}
