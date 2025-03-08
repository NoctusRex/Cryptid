import {Component} from '@angular/core';
import {BoardPartService} from "./services/board-part.service";
import {RulesService} from "./services/rules.service";
import {BoardService} from "./services/board.service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'cryptid';
  json = "";

  constructor(private boardPartService: BoardPartService, private rulesService: RulesService, private boardService: BoardService) {
  }

  generateBoardParts(): void {
    this.json = JSON.stringify(this.boardPartService.generate());
  }

  generateRules(): void {
    this.json = JSON.stringify(this.rulesService.generate());
  }

  generateBoards(): void {
    this.json = JSON.stringify(this.boardService.getRandomValidBoard());
  }
}
