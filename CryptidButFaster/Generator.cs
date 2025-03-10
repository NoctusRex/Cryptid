using CryptidButFaster.Models;
using FastDeepCloner;
using System.Collections.Concurrent;

namespace CryptidButFaster
{
    public class Generator
    {

        private List<BoardPart> InternalBoardParts { get; set; } = [];
        public List<BoardPart> BoardParts => DeepCloner.Clone(InternalBoardParts);

        private List<Rule> InternalRules { get; set; } = [];
        public List<Rule> Rules => DeepCloner.Clone(InternalRules);

        private List<Board> InternalBoards { get; set; } = [];
        public List<Board> Boards => DeepCloner.Clone(InternalBoards);

        private List<List<Rule>> InternalRuleSets { get; set; } = [];
        public List<List<Rule>> RuleSets => DeepCloner.Clone(InternalRuleSets);

        public void Generate()
        {
            GenerateBoardParts();
            GenerateRules();
            GenerateBoards();
        }

        private void GenerateBoardParts()
        {
            List<BoardPart> parts =
            [
        new ()            {
        Id = "1",
         Tiles=
        [
            new ()  {
            Coordinate= new Coordinate() { R= 0, Q= 0},
            Terrain= Terrains.River
          },
         new ()   {
            Coordinate= new Coordinate() { R= 1, Q= 0},
            Terrain= Terrains.River
          },
      new ()      {
           Coordinate= new Coordinate()  { R= 2, Q= 0},
            Terrain= Terrains.River
          },
     new ()       {
           Coordinate= new Coordinate()  { R= 3, Q= 0},
            Terrain= Terrains.River
          },
      new ()      {
           Coordinate= new Coordinate()  { R= 4, Q= 0},
            Terrain= Terrains.Forest
          },
      new ()      {
            Coordinate= new Coordinate(){ R= 5, Q= 0},
            Terrain= Terrains.Forest
          },
      new ()      {
            Coordinate= new Coordinate() { R= 0, Q= 1},
            Terrain= Terrains.Swamp
          },
    new ()        {
            Coordinate= new Coordinate()  { R= 1, Q= 1},
            Terrain= Terrains.Swamp
          },
    new ()        {
            Coordinate= new Coordinate() { R= 2, Q= 1},
            Terrain= Terrains.River
          },
   new ()         {
            Coordinate= new Coordinate() { R= 3, Q= 1},
            Terrain= Terrains.Desert
          },
   new ()         {
            Coordinate= new Coordinate() { R= 4, Q= 1},
            Terrain= Terrains.Forest
          },
  new ()          {
            Coordinate= new Coordinate() { R= 5, Q= 1},
            Terrain= Terrains.Forest
          },
      new ()      {
            Coordinate= new Coordinate() { R= 0, Q= 2},
            Terrain= Terrains.Swamp
          },
    new ()        {
            Coordinate= new Coordinate() { R= 1, Q= 2},
            Terrain= Terrains.Swamp
          },
    new ()        {
            Coordinate= new Coordinate() { R= 2, Q= 2},
            Terrain= Terrains.Desert
          },
    new ()        {
            Coordinate= new Coordinate() { R= 3, Q= 2},
            Terrain= Terrains.Desert,
            Territory= Territories.Bear
          },
    new ()        {
            Coordinate= new Coordinate() { R= 4, Q= 2},
            Terrain= Terrains.Desert,
            Territory= Territories.Bear
          },
      new ()      {
            Coordinate= new Coordinate() { R= 5, Q= 2},
            Terrain= Terrains.Forest,
            Territory= Territories.Bear
          }
        ]
      },
  new ()      {
        Id="2",
         Tiles= [
       new ()     {
            Coordinate= new Coordinate() {R= 0, Q= 0},
            Terrain= Terrains.Swamp,
            Territory= Territories.Puma
},
    new ()        {
Coordinate= new Coordinate() { R= 1, Q= 0},
            Terrain= Terrains.Forest,
            Territory= Territories.Puma
          },
     new ()       {
Coordinate= new Coordinate() { R= 2, Q= 0},
            Terrain= Terrains.Forest,
            Territory= Territories.Puma
          },
      new ()      {
Coordinate= new Coordinate() { R= 3, Q= 0},
            Terrain= Terrains.Forest
          },
     new ()       {
Coordinate= new Coordinate() { R= 4, Q= 0},
            Terrain= Terrains.Forest
          },
      new ()      {
Coordinate= new Coordinate() { R= 5, Q= 0},
            Terrain= Terrains.Forest
          },
    new ()        {
Coordinate= new Coordinate() { R= 0, Q= 1},
            Terrain= Terrains.Swamp
          },
     new ()       {
Coordinate= new Coordinate() { R= 1, Q= 1},
            Terrain= Terrains.Swamp
          },
     new ()       {
Coordinate= new Coordinate() { R= 2, Q= 1},
            Terrain= Terrains.Forest
          },
      new ()      {
Coordinate= new Coordinate() { R= 3, Q= 1},
            Terrain= Terrains.Desert
          },
      new ()      {
Coordinate= new Coordinate() { R= 4, Q= 1},
            Terrain= Terrains.Desert
          },
      new ()      {
Coordinate= new Coordinate() { R= 5, Q= 1},
            Terrain= Terrains.Desert
          },
       new ()     {
Coordinate= new Coordinate() { R= 0, Q= 2},
            Terrain= Terrains.Swamp
          },
       new ()     {
Coordinate= new Coordinate() { R= 1, Q= 2},
            Terrain= Terrains.Mountain
          },
      new ()      {
Coordinate= new Coordinate() { R= 2, Q= 2},
            Terrain= Terrains.Mountain
          },
      new ()      {
Coordinate= new Coordinate() { R= 3, Q= 2},
            Terrain= Terrains.Mountain
          },
      new ()      {
Coordinate= new Coordinate() { R= 4, Q= 2},
            Terrain= Terrains.Mountain
          },
       new ()     {
Coordinate= new Coordinate() { R= 5, Q= 2},
            Terrain= Terrains.Desert
          }
        ]
      },
   new ()     {
Id="3",
         Tiles=
    [
      new ()      {
    Coordinate= new Coordinate() { R= 0, Q= 0},
            Terrain= Terrains.Swamp
          },
    new ()        {
    Coordinate= new Coordinate() { R= 1, Q= 0},
            Terrain= Terrains.Swamp
          },
   new ()         {
    Coordinate= new Coordinate() { R= 2, Q= 0},
            Terrain= Terrains.Forest
          },
    new ()        {
    Coordinate= new Coordinate() { R= 3, Q= 0},
            Terrain= Terrains.Forest
          },
      new ()      {
    Coordinate= new Coordinate() { R= 4, Q= 0},
            Terrain= Terrains.Forest
          },
      new ()      {
    Coordinate= new Coordinate() { R= 5, Q= 0},
            Terrain= Terrains.River
          },
     new ()       {
    Coordinate= new Coordinate() { R= 0, Q= 1},
            Terrain= Terrains.Swamp,
            Territory= Territories.Puma
          },
       new ()     {
    Coordinate= new Coordinate() { R= 1, Q= 1},
            Terrain= Terrains.Swamp,
            Territory= Territories.Puma
          },
       new ()     {
    Coordinate= new Coordinate() { R= 2, Q= 1},
            Terrain= Terrains.Forest
          },
      new ()      {
    Coordinate= new Coordinate() { R= 3, Q= 1},
            Terrain= Terrains.Mountain
          },
      new ()      {
    Coordinate= new Coordinate() { R= 4, Q= 1},
            Terrain= Terrains.River
          },
      new ()      {
    Coordinate= new Coordinate() { R= 5, Q= 1},
            Terrain= Terrains.River
          },
      new ()      {
    Coordinate= new Coordinate() { R= 0, Q= 2},
            Terrain= Terrains.Mountain,
            Territory= Territories.Puma
          },
      new ()      {
    Coordinate= new Coordinate() { R= 1, Q= 2},
            Terrain= Terrains.Mountain
          },
       new ()     {
    Coordinate= new Coordinate() { R= 2, Q= 2},
            Terrain= Terrains.Mountain
          },
       new ()    {
    Coordinate= new Coordinate() { R= 3, Q= 2},
            Terrain= Terrains.Mountain
          },
        new ()    {
    Coordinate= new Coordinate() { R= 4, Q= 2},
            Terrain= Terrains.River
          },
     new ()       {
    Coordinate= new Coordinate() { R= 5, Q= 2},
            Terrain= Terrains.River
          }
        ]
      },
    new ()    {
Id="4",
         Tiles=
    [
       new ()     {
    Coordinate= new Coordinate() { R= 0, Q= 0},
            Terrain= Terrains.Desert
          },
      new ()      {
    Coordinate= new Coordinate() { R= 1, Q= 0},
            Terrain= Terrains.Desert
          },
    new ()        {
    Coordinate= new Coordinate() { R= 2, Q= 0},
            Terrain= Terrains.Mountain
          },
    new ()        {
    Coordinate= new Coordinate() { R= 3, Q= 0},
            Terrain= Terrains.Mountain
          },
      new ()      {
    Coordinate= new Coordinate() { R= 4, Q= 0},
            Terrain= Terrains.Mountain
          },
        new ()    {
    Coordinate= new Coordinate() { R= 5, Q= 0},
            Terrain= Terrains.Mountain
          },
      new ()      {
    Coordinate= new Coordinate() { R= 0, Q= 1},
            Terrain= Terrains.Desert
          },
      new ()      {
    Coordinate= new Coordinate() { R= 1, Q= 1},
            Terrain= Terrains.Desert
          },
       new ()     {
    Coordinate= new Coordinate() { R= 2, Q= 1},
            Terrain= Terrains.Mountain
          },
       new ()     {
    Coordinate= new Coordinate() { R= 3, Q= 1},
            Terrain= Terrains.River
          },
       new ()     {
    Coordinate= new Coordinate() { R= 4, Q= 1},
            Terrain= Terrains.River
          },
    new ()        {
    Coordinate= new Coordinate() { R= 5, Q= 1},
            Terrain= Terrains.River,
            Territory= Territories.Puma
          },
       new ()     {
    Coordinate= new Coordinate() { R= 0, Q= 2},
            Terrain= Terrains.Desert
          },
       new ()     {
    Coordinate= new Coordinate() { R= 1, Q= 2},
            Terrain= Terrains.Desert
          },
      new ()      {
    Coordinate= new Coordinate() { R= 2, Q= 2},
            Terrain= Terrains.Desert
          },
      new ()      {
    Coordinate= new Coordinate() { R= 3, Q= 2},
            Terrain= Terrains.Forest
          },
       new ()     {
    Coordinate= new Coordinate() { R= 4, Q= 2},
            Terrain= Terrains.Forest
          },
      new ()      {
    Coordinate= new Coordinate() { R= 5, Q= 2},
            Terrain= Terrains.Forest,
            Territory= Territories.Puma
          }
        ]
      },
    new ()    {
Id="5",
         Tiles=
    [
      new ()      {
    Coordinate= new Coordinate() { R= 0, Q= 0},
            Terrain= Terrains.Swamp
          },
      new ()      {
    Coordinate= new Coordinate() { R= 1, Q= 0},
            Terrain= Terrains.Swamp
          },
     new ()       {
    Coordinate= new Coordinate() { R= 2, Q= 0},
            Terrain= Terrains.Swamp
          },
     new ()       {
    Coordinate= new Coordinate() { R= 3, Q= 0},
            Terrain= Terrains.Mountain
          },
      new ()      {
    Coordinate= new Coordinate() { R= 4, Q= 0},
            Terrain= Terrains.Mountain
          },
       new ()     {
    Coordinate= new Coordinate() { R= 5, Q= 0},
            Terrain= Terrains.Mountain
          },
       new ()     {
    Coordinate= new Coordinate() { R= 0, Q= 1},
            Terrain= Terrains.Swamp
          },
     new ()       {
    Coordinate= new Coordinate() { R= 1, Q= 1},
            Terrain= Terrains.Desert
          },
      new ()      {
    Coordinate= new Coordinate() { R= 2, Q= 1},
            Terrain= Terrains.Desert
          },
      new ()      {
    Coordinate= new Coordinate() { R= 3, Q= 1},
            Terrain= Terrains.River
          },
       new ()     {
    Coordinate= new Coordinate() { R= 4, Q= 1},
            Terrain= Terrains.Mountain
          },
     new ()       {
    Coordinate= new Coordinate() { R= 5, Q= 1},
            Terrain= Terrains.Mountain,
            Territory= Territories.Bear
          },
        new ()    {
    Coordinate= new Coordinate() { R= 0, Q= 2},
            Terrain= Terrains.Desert
          },
    new ()       {
    Coordinate= new Coordinate() { R= 1, Q= 2},
            Terrain= Terrains.Desert
          },
      new ()      {
    Coordinate= new Coordinate() { R= 2, Q= 2},
            Terrain= Terrains.River
          },
       new ()     {
    Coordinate= new Coordinate() { R= 3, Q= 2},
            Terrain= Terrains.River
          },
       new ()     {
    Coordinate= new Coordinate() { R= 4, Q= 2},
            Terrain= Terrains.River,
            Territory= Territories.Bear
          },
      new ()      {
    Coordinate= new Coordinate() { R= 5, Q= 2},
            Terrain= Terrains.River,
            Territory= Territories.Bear
          }
        ]
      },
  new ()      {
Id="6",
         Tiles=
    [
     new ()       {
    Coordinate= new Coordinate() { R= 0, Q= 0},
            Terrain= Terrains.Desert,
            Territory= Territories.Bear
          },
      new ()      {
    Coordinate= new Coordinate() { R= 1, Q= 0},
            Terrain= Terrains.Desert
          },
       new ()     {
    Coordinate= new Coordinate() { R= 2, Q= 0},
            Terrain= Terrains.Swamp
          },
      new ()      {
    Coordinate= new Coordinate() { R= 3, Q= 0},
            Terrain= Terrains.Swamp
          },
      new ()      {
    Coordinate= new Coordinate() { R= 4, Q= 0},
            Terrain= Terrains.Swamp
          },
      new ()      {
    Coordinate= new Coordinate() { R= 5, Q= 0},
            Terrain= Terrains.Forest
          },
       new ()     {
    Coordinate= new Coordinate() { R= 0, Q= 1},
            Terrain= Terrains.Mountain,
            Territory= Territories.Bear
          },
       new ()     {
    Coordinate= new Coordinate() { R= 1, Q= 1},
            Terrain= Terrains.Mountain
          },
      new ()      {
    Coordinate= new Coordinate() { R= 2, Q= 1},
            Terrain= Terrains.Swamp
          },
      new ()      {
    Coordinate= new Coordinate() { R= 3, Q= 1},
            Terrain= Terrains.Swamp
          },
       new ()     {
    Coordinate= new Coordinate() { R= 4, Q= 1},
            Terrain= Terrains.Forest
          },
       new ()     {
    Coordinate= new Coordinate() { R= 5, Q= 1},
            Terrain= Terrains.Forest
          },
      new ()      {
    Coordinate= new Coordinate() { R= 0, Q= 2},
            Terrain= Terrains.Mountain
          },
      new ()      {
    Coordinate= new Coordinate() { R= 1, Q= 2},
            Terrain= Terrains.River
          },
      new ()      {
    Coordinate= new Coordinate() { R= 2, Q= 2},
            Terrain= Terrains.River
          },
      new ()      {
    Coordinate= new Coordinate() { R= 3, Q= 2},
            Terrain= Terrains.River
          },
       new ()     {
    Coordinate= new Coordinate() { R= 4, Q= 2},
            Terrain= Terrains.River
          },
       new ()     {
    Coordinate= new Coordinate() { R= 5, Q= 2},
            Terrain= Terrains.Forest
          }
        ]
      }
            ];

            parts.AddRange(RotateBoardParts(parts));
            InternalBoardParts = parts;
        }

        private static List<BoardPart> RotateBoardParts(List<BoardPart> parts)
        {
            return [.. parts.Select(x => {
                var newBoardPart = DeepCloner.Clone(x);
                newBoardPart.Id += 'r';

                newBoardPart.Tiles.ForEach(tile => {
                var q = 5 - tile.Coordinate.R;
                    var r = 2 - tile.Coordinate.Q;

                    tile.Coordinate = new Coordinate() { R = q, Q = r}
                    ;
                });

                return newBoardPart;
            })];
        }

        private void GenerateRules()
        {
            List<Rule> rules = [];

            var terrains = new List<Terrains> { Terrains.Swamp, Terrains.Forest, Terrains.Desert, Terrains.River, Terrains.Mountain };
            var structures = new List<Structures> { Structures.Hut, Structures.StoneThingy };
            var colors = new List<StructureColors> { StructureColors.Blue, StructureColors.Green, StructureColors.White, StructureColors.Black };
            var territories = new List<Territories> { Territories.Bear, Territories.Puma };
            var counter = 0;

            // 1) In one of two terrains - no duplicate terrains and order doesn't matter
            terrains.ForEach(t =>
            {
                terrains.ForEach(t2 =>
                {
                    if (t == t2) return;
                    if (rules.Any(x => x.Terrains != null && x.Terrains.All(y => y == t || y == t2))) return;

                    rules.Add(new()
                    {
                        Id = $"{++counter}",
                        Terrains = [t, t2],
                        Negated = false
                    });
                });
            });

            // 2) In range one of one terrain or any territory
            terrains.ForEach(t =>
            {
                rules.Add(new()
                {
                    Id = $"{++counter}",
                    Terrains = [t],
                    Range = 1,
                    Negated = false
                });
            });

            rules.Add(new()
            {
                Id = $"{++counter}",
                Territories = territories,
                Range = 1,
                Negated = false
            });

            // 3) In range of two of one building or territory
            territories.ForEach(t =>
            {
                rules.Add(new()
                {
                    Id = $"{++counter}",
                    Territories = [t],
                    Range = 2,
                    Negated = false
                });
            });

            structures.ForEach(s =>
            {
                rules.Add(new()
                {
                    Id = $"{++counter}",
                    Structures = [s],
                    Range = 2,
                    Negated = false
                });
            });

            // 4) In range of three of building color
            colors.ForEach((c) =>
            {
                rules.Add(new()
                {
                    Id = $"{++counter}",
                    Structures = structures,
                    StructureColor = c,
                    Range = 3,
                    Negated = false
                });
            });

            rules.AddRange(NegateRules(rules));
            InternalRules = rules;

            InternalRuleSets = GetCombinations(Rules, 4);
            InternalRuleSets = [.. InternalRuleSets.Where(x => x.Where(y => y.Range == null).Count() <= 2)];
            InternalRuleSets = [.. InternalRuleSets.Where(x => x.Where(y => y.Range != null && y.Range == 1).Count() <= 2)];
            InternalRuleSets = [.. InternalRuleSets.Where(x => x.Where(y => y.Range != null && y.Range == 2).Count() <= 2)];
            InternalRuleSets = [.. InternalRuleSets.Where(x => x.Where(y => y.Range != null && y.Range == 3).Count() <= 2)];
        }

        private List<List<T>> GetCombinations<T>(List<T> arr, int length)
        {
            List<List<T>> result = [];
            Combine(0, [], arr, length, result);
            return result;
        }

        private void Combine<T>(int start, List<T> path, List<T> arr, int length, List<List<T>> result)
        {
            if (path.Count == length)
            {
                result.Add([.. path]);
                return;
            }
            for (int i = start; i < arr.Count; i++)
            {
                path.Add(arr[i]);
                Combine(i + 1, path, arr, length, result);
                path.RemoveAt(path.Count - 1);
            }
        }

        private static List<Rule> NegateRules(List<Rule> rules)
        {
            return [.. DeepCloner.Clone(rules).Select(x => { x.Id += "-n"; x.Negated = true; return x; })];
        }

        private void GenerateBoards()
        {

            var parts = BoardParts.Select(x => new BoardPart { Id = x.Id, Tiles = [] }).ToList(); // remove tiles for performance
            var permutations = GeneratePermutations(parts, 6);
            var boards = new List<Board>();

            foreach (var permutation in permutations)
            {
                boards.Add(new Board
                {
                    Id = string.Empty,
                    Parts = permutation,
                    RuleSets = [],
                    Tiles = []
                });
            }

            InternalBoards = boards;
        }

        private static List<List<BoardPart>> GeneratePermutations(List<BoardPart> arr, int length)
        {
            List<List<BoardPart>> results = [];

            void Permute(List<BoardPart> current, List<BoardPart> remaining, HashSet<string> usedIds)
            {
                if (current.Count == length)
                {
                    results.Add([.. current]);
                    return;
                }

                for (int i = 0; i < remaining.Count; i++)
                {
                    BoardPart part = remaining[i];
                    var id = part.Id;
                    var counterpart = id.EndsWith('r') ? id[..^1] : id + "r";

                    if (usedIds.Contains(counterpart)) continue;

                    usedIds.Add(id);
                    current.Add(part);

                    List<BoardPart> newRemaining = [.. remaining];
                    newRemaining.RemoveAt(i);
                    Permute(current, newRemaining, usedIds);

                    current.RemoveAt(current.Count - 1);
                    usedIds.Remove(id);
                }
            }

            Permute([], [.. arr], []);

            return results;
        }
    }
}
