import {Terrains, Territories} from './enums.model';
import {Structure} from "./structure.model";
import {HexCoordinate} from "./coordinate.model";

export type BoardTile = {
  terrain: Terrains,
  structure?: Structure,
  territory?: Territories,
  hasCryptid?: boolean,
  coordinate: HexCoordinate
};
