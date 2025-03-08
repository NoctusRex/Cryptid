import {BoardPart} from "./board-part.model";
import {Rule} from "./rule.model";
import {BoardTile} from "./board-tile.model";

export type Board = {
  id: string,
  parts: Array<BoardPart>,
  rules: Array<Array<Rule>>,
  tiles: Array<BoardTile>
}
