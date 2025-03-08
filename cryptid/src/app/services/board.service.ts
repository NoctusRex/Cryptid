import {Injectable} from "@angular/core";
import {Board} from "../models/board.model";
import {BoardPartService} from "./board-part.service";
import {BoardPart} from "../models/board-part.model";
import {StructureColors, Structures} from "../models/enums.model";
import {Structure} from "../models/structure.model";
import {clone} from "../utils";
import {RulesService} from "./rules.service";
import {Rule} from "../models/rule.model";

@Injectable({providedIn: 'root'})
export class BoardService {

  constructor(private boardPartService: BoardPartService, private rulesService: RulesService) {
  }

  private _boards: Array<Board> = [];

  get boards(): Array<Board> {
    return clone(this._boards);
  }

  generate(): Array<Board> {
    this.boardPartService.generate();

    const parts = this.boardPartService.boardParts.map(x => ({...x, tiles: []} as BoardPart)); // remove tiles for performance
    const permutations = this.generatePermutations(parts, 6);
    const boards: Array<Board> = [];

    permutations.forEach((permutation) => {
      boards.push({
        id: "",
        parts: permutation,
        rules: [],
        tiles: []
      });
    });


    this._boards = boards;

    return this.boards;
  }

  public getRandomValidBoard(): Board {
    if (this._boards.length < 1) {
      this.generate();
    }

    const structures = [Structures.Hut, Structures.StoneThingy];
    const colors = [StructureColors.Blue, StructureColors.Green, StructureColors.White, StructureColors.Black];
    const parts = this.boardPartService.boardParts;
    let board: Board | undefined = undefined;
    let rules: Array<Array<Rule>> | undefined = undefined;

    while (!rules) {
      board = clone(this.boards[this.randomIntFromInterval(0, this.boards.length - 1)]);

      board.parts.forEach((part, i) => {
        const tiles = clone(parts.find(x => x.id === part.id)!.tiles);

        switch (i) {
          case 0:
            part.coordinate = {x: 0, y: 0};
            break;
          case 1:
            part.coordinate = {x: 0, y: 1};
            break;
          case 2:
            part.coordinate = {x: 1, y: 0};
            break;
          case 3:
            part.coordinate = {x: 1, y: 1};
            break;
          case 4:
            part.coordinate = {x: 2, y: 0};
            break;
          case 5:
            part.coordinate = {x: 2, y: 1};
            break;
        }

        tiles.forEach((tile) => {
          tile.coordinate.q = tile.coordinate.q + (part.coordinate!.x * 6);
          tile.coordinate.r = tile.coordinate.r + (part.coordinate!.y * 3);
        });

        board!.tiles.push(...tiles);
      });

      structures.forEach(id => {
        colors.forEach(color => {
          const structure: Structure = {id, color};

          const q = this.randomIntFromInterval(0, Math.max(...board!.tiles.map(x => x.coordinate.q)));
          const r = this.randomIntFromInterval(0, Math.max(...board!.tiles.map(x => x.coordinate.r)));

          board!.tiles.find(x => x.coordinate.q === q && x.coordinate.r === r)!.structure = structure;
        })
      })

      rules = this.rulesService.hasCryptid(board.tiles);
      if (!rules) {
        console.warn("invalid board");
      }
    }

    board!.rules = rules ?? [];

    return board!;
  }

  /**
   * ALL HAIL THE AI OVERLORDS
   * @returns The outer array holds all the permutations. The inner arrays represent individual permutations of the 6 selected board parts.
   */
  private generatePermutations(arr: Array<BoardPart>, length: number): Array<Array<BoardPart>> {
    let results: Array<Array<BoardPart>> = [];

    function permute(current: Array<BoardPart>, remaining: Array<BoardPart>, usedIds: Set<string>) {
      if (current.length === length) {
        results.push([...current]);
        return;
      }

      for (let i = 0; i < remaining.length; i++) {
        const part = remaining[i];
        const id = part.id;
        const counterpart = id.endsWith("r") ? id.slice(0, -1) : id + "r";

        // Skip if counterpart is already included
        if (usedIds.has(counterpart)) continue;

        // Include the current part
        usedIds.add(id);
        current.push(part);

        // Continue recursion with a new remaining array excluding the chosen part
        permute(current, remaining.slice(0, i).concat(remaining.slice(i + 1)), usedIds);

        // Backtrack
        current.pop();
        usedIds.delete(id);
      }
    }

    permute([], arr, new Set());

    return results;
  }

  /**
   *  min and max included
   */
  private randomIntFromInterval(min: number, max: number) {
    return Math.floor(Math.random() * (max - min + 1) + min);
  }
}
