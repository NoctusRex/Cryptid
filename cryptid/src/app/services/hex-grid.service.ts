import {Injectable} from "@angular/core";
import {BoardTile} from "../models/board-tile.model";


@Injectable({providedIn: 'root'})
export class HexGridService {

  getInRange(board: Array<BoardTile>, centerTile: BoardTile, range: number): Array<BoardTile> {
    const neighbours: BoardTile[] = [];

    for (let dq = -range; dq <= range; dq++) {
      const minDr = Math.max(-range, -dq - range);
      const maxDr = Math.min(range, -dq + range);

      for (let dr = minDr; dr <= maxDr; dr++) {
        const coordinate = {q: centerTile.coordinate.q + dq, r: centerTile.coordinate.r + dr};
        const tile = board.find(x => x.coordinate.q === coordinate.q && x.coordinate.r === coordinate.r);
        if (tile) {
          neighbours.push(tile);
        }
      }
    }

    return neighbours;
  }

}
