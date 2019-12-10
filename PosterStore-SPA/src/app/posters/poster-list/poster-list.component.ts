import { Component, OnInit } from '@angular/core';
import { Poster } from '../../_models/poster';
import { PosterService } from '../../_services/poster.service';
import { ActivatedRoute } from '@angular/router';
import { Pagination, PaginatedResult } from 'src/app/_models/pagination';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { PageChangedEvent } from 'ngx-bootstrap';

@Component({
  selector: 'app-poster-list',
  templateUrl: './poster-list.component.html',
  styleUrls: ['./poster-list.component.css']
})
export class PosterListComponent implements OnInit {
  posters: Poster[];
  pagination: Pagination;
  constructor(private posterService: PosterService, private alertify: AlertifyService,
      private route: ActivatedRoute) { }

  ngOnInit() {
    // this.loadPosters();
    this.route.data.subscribe(data => {
      this.posters = data['posters'].result;
      this.pagination = data['posters'].pagination;
    });
  }

  pageChanged(event: PageChangedEvent): void {
    this.pagination.currentPage = event.page;
    this.loadPosters();
  }

  loadPosters() {
    this.posterService.getPosters(this.pagination.currentPage, this.pagination.itemsPerPage)
      .subscribe((res: PaginatedResult<Poster[]>) => {
        this.posters = res.result;
        this.pagination = res.pagination;
    }, error => {
      this.alertify.error(error);
    });
  }

}
