import { TestBed, inject } from '@angular/core/testing';

import { BoardGamesService } from './board-games.service';

describe('BoardGamesService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [BoardGamesService]
    });
  });

  it('should be created', inject([BoardGamesService], (service: BoardGamesService) => {
    expect(service).toBeTruthy();
  }));
});
