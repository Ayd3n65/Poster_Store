/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { PosterService } from './poster.service';

describe('Service: Poster', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PosterService]
    });
  });

  it('should ...', inject([PosterService], (service: PosterService) => {
    expect(service).toBeTruthy();
  }));
});
