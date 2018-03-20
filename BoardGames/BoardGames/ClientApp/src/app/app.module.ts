import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { MatTableModule } from '@angular/material/table';

import { BoardGamesService } from './services/board-games.service';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { BoardGamesComponent } from './board-games/board-games.component';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    BoardGamesComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: BoardGamesComponent, pathMatch: 'full' }
    ]),
    MatTableModule
  ],
  providers: [BoardGamesService],
  bootstrap: [AppComponent]
})
export class AppModule { }
