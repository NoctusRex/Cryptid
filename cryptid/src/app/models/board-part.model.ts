import {BoardTile} from "./board-tile.model";
import {Coordinate} from "./coordinate.model";

export type BoardPart = {
  id: string,
  tiles: Array<BoardTile>,
  coordinate?: Coordinate
}
