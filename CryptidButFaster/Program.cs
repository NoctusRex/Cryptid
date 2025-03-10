using CryptidButFaster.Models;
using FastDeepCloner;

CryptidButFaster.Generator generator = new();
Console.WriteLine("Generate base data");
generator.Generate();

var generatorRuleSets = generator.RuleSets;
var tileKeys = new List<string>();
var random = new Random();

GenerateRandomBoards(5);

void GenerateRandomBoards(int count)
{
    var possibleStructures = GetPossibleStructures();
    var boards = generator.Boards;
    var parts = DeepCloner.Clone(generator.BoardParts);

    for (int i = 0; i < count; i++)
    {
        Console.WriteLine("Prepare Board");
        var board = boards[random.Next(0, generator.Boards.Count)];

        var j = 0;
        board.Parts.ForEach(part =>
        {
            var tiles = DeepCloner.Clone(parts.First(x => x.Id == part.Id).Tiles);

            switch (j)
            {
                case 0:
                    part.Coordinate = new() { Q = 0, R = 0 };
                    break;
                case 1:
                    part.Coordinate = new() { Q = 0, R = 1 };
                    break;
                case 2:
                    part.Coordinate = new() { Q = 1, R = 0 };
                    break;
                case 3:
                    part.Coordinate = new() { Q = 1, R = 1 };
                    break;
                case 4:
                    part.Coordinate = new() { Q = 2, R = 0 };
                    break;
                case 5:
                    part.Coordinate = new() { Q = 2, R = 1 };
                    break;
            }

            tiles.ForEach((tile) =>
            {
                tile.Coordinate.R = tile.Coordinate.R + (part.Coordinate!.R * 6);
                tile.Coordinate.Q = tile.Coordinate.Q + (part.Coordinate!.Q * 3);
            });

            board.Tiles.AddRange(tiles);

            j++;
        });

        GenerateBoard(board, GetRandomCombination(possibleStructures.Count));
    }
}

void GenerateBoard(Board board, List<Coordinate> combination, int max = 1)
{
    Console.WriteLine("Generate Board");

    var possibleStructures = GetPossibleStructures();
    var random = new Random();

    var newBoard = DeepCloner.Clone(board);

    for (int i = 0; i < combination.Count; i++)
    {
        newBoard.Tiles.First(t => t.Coordinate.R == combination[i].R && t.Coordinate.Q == combination[i].Q).Structure = possibleStructures[i];
    }

    var ruleCache = GetRuleCache(newBoard.Tiles);

    if (tileKeys.Count == 0)
    {
        tileKeys = [.. ruleCache.Values.First().Select(x => x.Key)];
    }

    Console.WriteLine("Check Board");
    var rules = HasCryptid(ruleCache);
    if (rules != null && rules.Count > 1)
    {
        Console.WriteLine($"Found match");

        newBoard.RuleCache = ruleCache;
        newBoard.Rules = generator.Rules;
        newBoard.Id = string.Join("-", newBoard.Parts.Select(x => x.Id)) + " " + Guid.NewGuid().ToString();
        newBoard.RuleSets = [.. rules.Select(x =>
            {
                var cryptid = GetCryptid(x, ruleCache);
                var ruleSet = new RuleSet
                {
                    Rules = [.. x.Select(x => x.Id)],
                    Cryptid = Coordinate.FromString(cryptid)
                };

                return ruleSet;
            }).Where(x => x.Cryptid != null)];

        Console.WriteLine($"Save file");
        File.WriteAllText($"./boards/{newBoard.Id}.json", Newtonsoft.Json.JsonConvert.SerializeObject(newBoard, Newtonsoft.Json.Formatting.Indented));
    }
    else
    {
        Console.WriteLine($"No match");
    }
}

List<List<Rule>>? HasCryptid(Dictionary<string, Dictionary<string, bool>> ruleCache)
{
    var matchingRuleSets = new List<List<Rule>>();

    Parallel.ForEach(generatorRuleSets, (rulesSet, i, v) =>
    {
        var tilesToCheck = DeepCloner.Clone(tileKeys);
        var lastTileCount = int.MaxValue;

        foreach (var rule in rulesSet)
        {
            // Check only tiles nessecary
            tilesToCheck = [.. tilesToCheck.Where(x => ruleCache[rule.Id][x.ToString()])];

            // If tile count does not reduce, don't use the ruleset
            if (lastTileCount == tilesToCheck.Count) break;
            lastTileCount = tilesToCheck.Count;
        }

        if (lastTileCount == 1) matchingRuleSets.Add(rulesSet);
    });

    return matchingRuleSets.Count > 1 ? matchingRuleSets : null;
}

string? GetCryptid(List<Rule> ruleSet, Dictionary<string, Dictionary<string, bool>> ruleCache)
{
    var ruleResults = ruleCache.ToList().Where(x => ruleSet.Any(y => x.Key == y.Id)).SelectMany(x => x.Value).Where(x => x.Value).Select(x => x.Key);
    var groupedResults = ruleResults.GroupBy(x => x).Where(g => g.Count() == ruleSet.Count).Select(x => x.Key);

    return groupedResults.SingleOrDefault();
}

Dictionary<string, Dictionary<string, bool>> GetRuleCache(List<BoardTile> tiles)
{
    var ruleCache = new Dictionary<string, Dictionary<string, bool>>();

    generator.Rules.ForEach(rule =>
    {
        tiles.ForEach(tile =>
        {
            var result = ValidateRule(rule, tile, tiles);

            if (!ruleCache.ContainsKey(rule.Id)) ruleCache.Add(rule.Id, []);
            ruleCache[rule.Id].Add(tile.Coordinate.ToString(), result);
        });
    });

    return ruleCache;
}

List<BoardTile> GetInRange(List<BoardTile> board, BoardTile centerTile, int range)
{
    List<BoardTile> neighbours = [];

    for (int dq = -range; dq <= range; dq++)
    {
        int minDr = Math.Max(-range, -dq - range);
        int maxDr = Math.Min(range, -dq + range);

        for (int dr = minDr; dr <= maxDr; dr++)
        {
            var coordinate = new Coordinate { R = centerTile.Coordinate.R + dq, Q = centerTile.Coordinate.Q + dr };
            var tile = board.FirstOrDefault(x => x.Coordinate.R == coordinate.R && x.Coordinate.Q == coordinate.Q);
            if (tile != null) neighbours.Add(tile);
        }
    }

    return neighbours;
}

bool ValidateRule(Rule rule, BoardTile tile, List<BoardTile> tiles)
{
    List<BoardTile> neighbours = [];
    bool result = false;

    if (rule.Range.HasValue && rule.Range > 0)
    {
        neighbours = GetInRange(tiles, tile, rule.Range.Value);
    }

    switch (rule.Range)
    {
        case 1:
            if (rule.Terrains != null)
            {
                result = neighbours.Any(x => rule.Terrains.All(y => y == x.Terrain));
                return rule.Negated ? !result : result;
            }

            if (rule.Territories != null)
            {
                result = neighbours.Any(x => x.Territory != null);
                return rule.Negated ? !result : result;
            }

            return false;

        case 2:
            if (rule.Structures != null)
            {
                result = neighbours.Any(x => rule.Structures.All(y => y == x.Structure?.Id));
                return rule.Negated ? !result : result;
            }

            if (rule.Territories != null)
            {
                result = neighbours.Any(x => rule.Territories.All(y => y == x.Territory));
                return rule.Negated ? !result : result;
            }

            return false;

        case 3:
            if (rule.StructureColor != null)
            {
                result = neighbours.Any(x => rule.StructureColor == x.Structure?.Color);
                return rule.Negated ? !result : result;
            }

            return false;

        default:
            result = rule.Terrains != null && rule.Terrains.Any(x => x == tile.Terrain);
            return rule.Negated ? !result : result;
    }
}

List<Coordinate> GetRandomCombination(int count)
{
    var result = new List<Coordinate>();

    while(result.Count < count)
    {
        var coord = new Coordinate() { Q = random.Next(0, 3 * 3), R = random.Next(0, 6 * 2) };
        if (result.Where(x => x.ToString() == coord.ToString()).Any()) continue;

        result.Add(coord);
    }

    return result;
}

static IEnumerable<List<T>> GetCombinations<T>(List<T> elements, int k)
{
    int n = elements.Count;
    if (k > n) yield break;

    int[] indices = [.. Enumerable.Range(0, k)];

    while (true)
    {
        yield return indices.Select(i => elements[i]).ToList();

        int i = k - 1;
        while (i >= 0 && indices[i] == i + n - k) i--;

        if (i < 0) break;

        indices[i]++;
        for (int j = i + 1; j < k; j++)
            indices[j] = indices[j - 1] + 1;
    }
}

static List<Structure> GetPossibleStructures()
{
    var structures = Enum.GetValues<Structures>().Cast<Structures>().ToList();
    var colors = Enum.GetValues<StructureColors>().Cast<StructureColors>().ToList();

    List<Structure> possibleStructures = [];

    foreach (var structure in structures)
        foreach (var color in colors)
            possibleStructures.Add(new Structure { Id = structure, Color = color });

    return possibleStructures;
}
