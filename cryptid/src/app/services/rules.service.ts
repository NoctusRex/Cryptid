import {Injectable} from "@angular/core";
import {Rule} from "../models/rule.model";
import {BoardTile} from "../models/board-tile.model";
import {StructureColors, Structures, Terrains, Territories} from "../models/enums.model";
import {clone} from "../utils";
import {HexGridService} from "./hex-grid.service";

@Injectable({providedIn: 'root'})
export class RulesService {

  constructor(private readonly gridService: HexGridService) {
  }

  private _rules: Array<Rule> = [];

  public get rules(): Array<Rule> {
    return clone(this._rules);
  }

  generate(): Array<Rule> {
    const terrains = [Terrains.Swamp, Terrains.Forest, Terrains.Desert, Terrains.River, Terrains.Mountain];
    const structures = [Structures.Hut, Structures.StoneThingy];
    const colors = [StructureColors.Blue, StructureColors.Green, StructureColors.White, StructureColors.Black];
    const territories = [Territories.Bear, Territories.Puma];

    const rules: Array<Rule> = [];

    // 1) In one of two terrains - no duplicate terrains and order doesn't matter
    terrains.forEach((t) => {
      terrains.forEach((t2) => {
        if (t === t2) {
          return;
        }

        if (rules.some(x => x.terrains?.every(y => y === t || y === t2))) {
          return;
        }

        rules.push({
          terrains: [t, t2],
          negated: false
        });
      })
    })

    // 2) In range one of one terrain or any territory
    terrains.forEach((t) => {
      rules.push({
        terrains: [t],
        range: 1,
        negated: false
      });
    })

    rules.push({
      territories,
      range: 1,
      negated: false
    });

    // 3) In range of two of one building or territory
    territories.forEach((t) => {
      rules.push({
        territories: [t],
        range: 2,
        negated: false
      });
    })

    structures.forEach((s => {
      rules.push({
        structures: [s],
        range: 2,
        negated: false
      });
    }))

    // 4) In range of three of building color
    colors.forEach((c) => {
      rules.push({
        structures,
        structureColor: c,
        range: 3,
        negated: false
      });
    })

    // 5) All rules but negated
    rules.push(...this.negateRules((rules)));
    this._rules = rules;

    return this.rules;
  }

  /**
   * Returns matching sets of rules
   */
  hasCryptid(tiles: Array<BoardTile>): Array<Array<Rule>> | undefined {
    if (this.rules.length < 1) {
      this.generate();
    }

    const ruleCombinations = this.getCombinations(this.rules, 4);
    let matchingRuleSets: Array<Array<Rule>> = [];

    ruleCombinations.forEach((rules) => {
      let foundOnlyOneCryptid: boolean | undefined = undefined;

      tiles.forEach(tile => {
        if (foundOnlyOneCryptid !== undefined && !foundOnlyOneCryptid) {
          return;
        }

        let foundCryptid = true;

        rules.forEach((rule) => {
          if (!this.validate(rule, tile, tiles)) {
            foundCryptid = false;
          }
        });

        if (foundCryptid) {
          tile.hasCryptid = true;

          if (foundOnlyOneCryptid === undefined) {
            foundOnlyOneCryptid = true;
          } else if (foundOnlyOneCryptid) {
            foundOnlyOneCryptid = false;
          }
        }
      });

      if (foundOnlyOneCryptid) {
        matchingRuleSets.push(rules);
      }
    });

    return matchingRuleSets.length > 1 ? matchingRuleSets : undefined;
  }

  validate(rule: Rule, tile: BoardTile, tiles: Array<BoardTile>): boolean {
    let neighbours: Array<BoardTile> = [];
    let result = false;
    if (rule.range && rule.range > 0) {
      neighbours = this.gridService.getInRange(tiles, tile, rule.range);
    }

    switch (rule.range) {
      case 1:
        if (rule.terrains) {
          result = neighbours.some(x => rule.terrains!.every(y => y === x.terrain));

          return rule.negated ? !result : result;
        }

        if (rule.territories) {
          result = neighbours.some(x => x.territory !== undefined);

          return rule.negated ? !result : result;
        }

        return false;

      case 2:
        if (rule.structures) {
          result = neighbours.some(x => rule.structures!.every(y => y === x.structure?.id));

          return rule.negated ? !result : result;
        }

        if (rule.territories) {
          result = neighbours.some(x => rule.territories!.every(y => y === x.territory));

          return rule.negated ? !result : result;
        }

        return false;

      case 3:
        if (rule.structureColor) {
          result = neighbours.some(x => rule.structureColor === x.structure?.color);

          return rule.negated ? !result : result;
        }

        return false;

      default:
        result = rule.terrains!.some(x => x === tile.terrain);

        return rule.negated ? !result : result;
    }
  }

  private negateRules(rules: Array<Rule>): Array<Rule> {
    return rules.map(x => ({...x, negated: true} as Rule))
  }

  /**
   * ALL HAIL THE AI OVERLORD
   */
  private getCombinations<T>(arr: Array<T>, length: number): Array<Array<T>> {
    function combine(start: number, path: T[]): void {
      if (path.length === length) {
        result.push([...path]);
        return;
      }
      for (let i = start; i < arr.length; i++) {
        path.push(arr[i]);
        combine(i + 1, path);
        path.pop();
      }
    }

    const result: Array<Array<T>> = [];
    combine(0, []);
    return result;
  }
}
