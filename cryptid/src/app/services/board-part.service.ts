import {Injectable} from "@angular/core";
import {BoardPart} from "../models/board-part.model";
import {Terrains, Territories} from "../models/enums.model";
import {clone} from "../utils";

@Injectable({providedIn: "root"})
export class BoardPartService {

  private _boardParts: Array<BoardPart> = [];

  public get boardParts(): Array<BoardPart> {
    return clone(this._boardParts);
  }

  generate(): Array<BoardPart> {
    const parts: Array<BoardPart> = [
      {
        id: "1",
        tiles: [
          {
            coordinate: {q: 0, r: 0},
            terrain: Terrains.River
          },
          {
            coordinate: {q: 1, r: 0},
            terrain: Terrains.River
          },
          {
            coordinate: {q: 2, r: 0},
            terrain: Terrains.River
          },
          {
            coordinate: {q: 3, r: 0},
            terrain: Terrains.River
          },
          {
            coordinate: {q: 4, r: 0},
            terrain: Terrains.Forest
          },
          {
            coordinate: {q: 5, r: 0},
            terrain: Terrains.Forest
          },
          {
            coordinate: {q: 0, r: 1},
            terrain: Terrains.Swamp
          },
          {
            coordinate: {q: 1, r: 1},
            terrain: Terrains.Swamp
          },
          {
            coordinate: {q: 2, r: 1},
            terrain: Terrains.River
          },
          {
            coordinate: {q: 3, r: 1},
            terrain: Terrains.Desert
          },
          {
            coordinate: {q: 4, r: 1},
            terrain: Terrains.Forest
          },
          {
            coordinate: {q: 5, r: 1},
            terrain: Terrains.Forest
          },
          {
            coordinate: {q: 0, r: 2},
            terrain: Terrains.Swamp
          },
          {
            coordinate: {q: 1, r: 2},
            terrain: Terrains.Swamp
          },
          {
            coordinate: {q: 2, r: 2},
            terrain: Terrains.Desert
          },
          {
            coordinate: {q: 3, r: 2},
            terrain: Terrains.Desert,
            territory: Territories.Bear
          },
          {
            coordinate: {q: 4, r: 2},
            terrain: Terrains.Desert,
            territory: Territories.Bear
          },
          {
            coordinate: {q: 5, r: 2},
            terrain: Terrains.Forest,
            territory: Territories.Bear
          }
        ]
      },
      {
        id: "2",
        tiles: [
          {
            coordinate: {q: 0, r: 0},
            terrain: Terrains.Swamp,
            territory: Territories.Puma
          },
          {
            coordinate: {q: 1, r: 0},
            terrain: Terrains.Forest,
            territory: Territories.Puma
          },
          {
            coordinate: {q: 2, r: 0},
            terrain: Terrains.Forest,
            territory: Territories.Puma
          },
          {
            coordinate: {q: 3, r: 0},
            terrain: Terrains.Forest
          },
          {
            coordinate: {q: 4, r: 0},
            terrain: Terrains.Forest
          },
          {
            coordinate: {q: 5, r: 0},
            terrain: Terrains.Forest
          },
          {
            coordinate: {q: 0, r: 1},
            terrain: Terrains.Swamp
          },
          {
            coordinate: {q: 1, r: 1},
            terrain: Terrains.Swamp
          },
          {
            coordinate: {q: 2, r: 1},
            terrain: Terrains.Forest
          },
          {
            coordinate: {q: 3, r: 1},
            terrain: Terrains.Desert
          },
          {
            coordinate: {q: 4, r: 1},
            terrain: Terrains.Desert
          },
          {
            coordinate: {q: 5, r: 1},
            terrain: Terrains.Desert
          },
          {
            coordinate: {q: 0, r: 2},
            terrain: Terrains.Swamp
          },
          {
            coordinate: {q: 1, r: 2},
            terrain: Terrains.Mountain
          },
          {
            coordinate: {q: 2, r: 2},
            terrain: Terrains.Mountain
          },
          {
            coordinate: {q: 3, r: 2},
            terrain: Terrains.Mountain
          },
          {
            coordinate: {q: 4, r: 2},
            terrain: Terrains.Mountain
          },
          {
            coordinate: {q: 5, r: 2},
            terrain: Terrains.Desert
          }
        ]
      },
      {
        id: "3",
        tiles: [
          {
            coordinate: {q: 0, r: 0},
            terrain: Terrains.Swamp
          },
          {
            coordinate: {q: 1, r: 0},
            terrain: Terrains.Swamp
          },
          {
            coordinate: {q: 2, r: 0},
            terrain: Terrains.Forest
          },
          {
            coordinate: {q: 3, r: 0},
            terrain: Terrains.Forest
          },
          {
            coordinate: {q: 4, r: 0},
            terrain: Terrains.Forest
          },
          {
            coordinate: {q: 5, r: 0},
            terrain: Terrains.River
          },
          {
            coordinate: {q: 0, r: 1},
            terrain: Terrains.Swamp,
            territory: Territories.Puma
          },
          {
            coordinate: {q: 1, r: 1},
            terrain: Terrains.Swamp,
            territory: Territories.Puma
          },
          {
            coordinate: {q: 2, r: 1},
            terrain: Terrains.Forest
          },
          {
            coordinate: {q: 3, r: 1},
            terrain: Terrains.Mountain
          },
          {
            coordinate: {q: 4, r: 1},
            terrain: Terrains.River
          },
          {
            coordinate: {q: 5, r: 1},
            terrain: Terrains.River
          },
          {
            coordinate: {q: 0, r: 2},
            terrain: Terrains.Mountain,
            territory: Territories.Puma
          },
          {
            coordinate: {q: 1, r: 2},
            terrain: Terrains.Mountain
          },
          {
            coordinate: {q: 2, r: 2},
            terrain: Terrains.Mountain
          },
          {
            coordinate: {q: 3, r: 2},
            terrain: Terrains.Mountain
          },
          {
            coordinate: {q: 4, r: 2},
            terrain: Terrains.River
          },
          {
            coordinate: {q: 5, r: 2},
            terrain: Terrains.River
          }
        ]
      },
      {
        id: "4",
        tiles: [
          {
            coordinate: {q: 0, r: 0},
            terrain: Terrains.Desert
          },
          {
            coordinate: {q: 1, r: 0},
            terrain: Terrains.Desert
          },
          {
            coordinate: {q: 2, r: 0},
            terrain: Terrains.Mountain
          },
          {
            coordinate: {q: 3, r: 0},
            terrain: Terrains.Mountain
          },
          {
            coordinate: {q: 4, r: 0},
            terrain: Terrains.Mountain
          },
          {
            coordinate: {q: 5, r: 0},
            terrain: Terrains.Mountain
          },
          {
            coordinate: {q: 0, r: 1},
            terrain: Terrains.Desert
          },
          {
            coordinate: {q: 1, r: 1},
            terrain: Terrains.Desert
          },
          {
            coordinate: {q: 2, r: 1},
            terrain: Terrains.Mountain
          },
          {
            coordinate: {q: 3, r: 1},
            terrain: Terrains.River
          },
          {
            coordinate: {q: 4, r: 1},
            terrain: Terrains.River
          },
          {
            coordinate: {q: 5, r: 1},
            terrain: Terrains.River,
            territory: Territories.Puma
          },
          {
            coordinate: {q: 0, r: 2},
            terrain: Terrains.Desert
          },
          {
            coordinate: {q: 1, r: 2},
            terrain: Terrains.Desert
          },
          {
            coordinate: {q: 2, r: 2},
            terrain: Terrains.Desert
          },
          {
            coordinate: {q: 3, r: 2},
            terrain: Terrains.Forest
          },
          {
            coordinate: {q: 4, r: 2},
            terrain: Terrains.Forest
          },
          {
            coordinate: {q: 5, r: 2},
            terrain: Terrains.Forest,
            territory: Territories.Puma
          }
        ]
      },
      {
        id: "5",
        tiles: [
          {
            coordinate: {q: 0, r: 0},
            terrain: Terrains.Swamp
          },
          {
            coordinate: {q: 1, r: 0},
            terrain: Terrains.Swamp
          },
          {
            coordinate: {q: 2, r: 0},
            terrain: Terrains.Swamp
          },
          {
            coordinate: {q: 3, r: 0},
            terrain: Terrains.Mountain
          },
          {
            coordinate: {q: 4, r: 0},
            terrain: Terrains.Mountain
          },
          {
            coordinate: {q: 5, r: 0},
            terrain: Terrains.Mountain
          },
          {
            coordinate: {q: 0, r: 1},
            terrain: Terrains.Swamp
          },
          {
            coordinate: {q: 1, r: 1},
            terrain: Terrains.Desert
          },
          {
            coordinate: {q: 2, r: 1},
            terrain: Terrains.Desert
          },
          {
            coordinate: {q: 3, r: 1},
            terrain: Terrains.River
          },
          {
            coordinate: {q: 4, r: 1},
            terrain: Terrains.Mountain
          },
          {
            coordinate: {q: 5, r: 1},
            terrain: Terrains.Mountain,
            territory: Territories.Bear
          },
          {
            coordinate: {q: 0, r: 2},
            terrain: Terrains.Desert
          },
          {
            coordinate: {q: 1, r: 2},
            terrain: Terrains.Desert
          },
          {
            coordinate: {q: 2, r: 2},
            terrain: Terrains.River
          },
          {
            coordinate: {q: 3, r: 2},
            terrain: Terrains.River
          },
          {
            coordinate: {q: 4, r: 2},
            terrain: Terrains.River,
            territory: Territories.Bear
          },
          {
            coordinate: {q: 5, r: 2},
            terrain: Terrains.River,
            territory: Territories.Bear
          }
        ]
      },
      {
        id: "6",
        tiles: [
          {
            coordinate: {q: 0, r: 0},
            terrain: Terrains.Desert,
            territory: Territories.Bear,
          },
          {
            coordinate: {q: 1, r: 0},
            terrain: Terrains.Desert
          },
          {
            coordinate: {q: 2, r: 0},
            terrain: Terrains.Swamp
          },
          {
            coordinate: {q: 3, r: 0},
            terrain: Terrains.Swamp
          },
          {
            coordinate: {q: 4, r: 0},
            terrain: Terrains.Swamp
          },
          {
            coordinate: {q: 5, r: 0},
            terrain: Terrains.Forest
          },
          {
            coordinate: {q: 0, r: 1},
            terrain: Terrains.Mountain,
            territory: Territories.Bear
          },
          {
            coordinate: {q: 1, r: 1},
            terrain: Terrains.Mountain
          },
          {
            coordinate: {q: 2, r: 1},
            terrain: Terrains.Swamp
          },
          {
            coordinate: {q: 3, r: 1},
            terrain: Terrains.Swamp
          },
          {
            coordinate: {q: 4, r: 1},
            terrain: Terrains.Forest
          },
          {
            coordinate: {q: 5, r: 1},
            terrain: Terrains.Forest
          },
          {
            coordinate: {q: 0, r: 2},
            terrain: Terrains.Mountain
          },
          {
            coordinate: {q: 1, r: 2},
            terrain: Terrains.River
          },
          {
            coordinate: {q: 2, r: 2},
            terrain: Terrains.River
          },
          {
            coordinate: {q: 3, r: 2},
            terrain: Terrains.River
          },
          {
            coordinate: {q: 4, r: 2},
            terrain: Terrains.River
          },
          {
            coordinate: {q: 5, r: 2},
            terrain: Terrains.Forest
          }
        ]
      }
    ];

    parts.push(...this.rotate(parts));
    this._boardParts = parts;

    return this.boardParts;
  }

  private rotate(parts: Array<BoardPart>): Array<BoardPart> {
    return parts.map(x => {
      const newBoardPart: BoardPart = clone(x);
      newBoardPart.id += `r`;

      newBoardPart.tiles.forEach(tile => {
        const q = 5 - tile.coordinate.q;
        const r = 2 - tile.coordinate.r;

        tile.coordinate = {q, r};
      });

      return newBoardPart;
    });
  }
}
