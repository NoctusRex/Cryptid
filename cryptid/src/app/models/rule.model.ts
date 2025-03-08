import {StructureColors, Structures, Terrains, Territories} from "./enums.model";

/**
 * 1) In one of two terrains
 * 2) In range one of one terrain or any territory
 * 3) In range of two of one building or territory
 * 4) In range of three of building color
 */
export type Rule = {
  negated: boolean,
  range?: number,
  terrains?: Array<Terrains>,
  territories?: Array<Territories>,
  structures?: Array<Structures>,
  structureColor?: StructureColors
};
