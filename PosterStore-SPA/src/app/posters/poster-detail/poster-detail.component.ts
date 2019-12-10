import { Component, OnInit } from '@angular/core';
import { Poster } from 'src/app/_models/poster';
import { PosterService } from 'src/app/_services/poster.service';
import { ActivatedRoute } from '@angular/router';
import { AlertifyService } from 'src/app/_services/alertify.service';

@Component({
  selector: 'app-poster-detail',
  templateUrl: './poster-detail.component.html',
  styleUrls: ['./poster-detail.component.css']
})
export class PosterDetailComponent implements OnInit {
  poster: Poster;
  constructor(private posterService: PosterService, private route: ActivatedRoute, private alertify: AlertifyService) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.poster = data['poster'];
    });
    // this.loadPoster();
  }
  // poster/2 - param
  // loadPoster() {
  //   this.posterService.getPoster(+this.route.snapshot.params['id'])
  //       .subscribe((poster: Poster) => {
  //         this.poster = poster;
  //       }, error => {
  //         this.alertify.error(error);
  //       }); // + конвертит в number из string
  // }

}
