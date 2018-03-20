import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import { BoardGame } from '../models/board-game.model';

@Injectable()
export class BoardGamesService {
  private serviceUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.serviceUrl = baseUrl + 'api/BoardGames/AllGames';
  }

  getBoardGames(): Observable<BoardGame[]> {
    return this.http.get<BoardGame[]>(this.serviceUrl);
  }
}
