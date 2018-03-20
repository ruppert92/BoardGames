import { Component, OnInit  } from '@angular/core';
import { BoardGamesService } from '../services/board-games.service';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/of';
import { DataSource } from '@angular/cdk/collections';
import { BoardGame } from '../models/board-game.model';

@Component({
  selector: 'app-board-games',
  templateUrl: './board-games.component.html'
})
export class BoardGamesComponent implements OnInit {
  datasource = new BoardGamesDataSource(this.boardGamesService);
  displayedColumns = ['name', 'minPlayers', 'maxPlayers', 'minLength', 'maxLength', 'played'];

  constructor(private boardGamesService: BoardGamesService) { }

  ngOnInit() {
  }
}

export class BoardGamesDataSource extends DataSource<any> {
  constructor(private boardGamesService: BoardGamesService) {
    super();
  }
  connect(): Observable<BoardGame[]> {
    return this.boardGamesService.getBoardGames();
  }
  disconnect() { }
}
