namespace CryptidButFaster.Models
{
    public class Board
    {
        public string Id { get; set; }
        public List<BoardPart> Parts { get; set; } = [];
        public List<Rule> Rules { get; set; } = [];
        public List<RuleSet> RuleSets { get; set; } = [];
        public List<BoardTile> Tiles { get; set; } = [];
        public Dictionary<string, Dictionary<string, bool>> RuleCache { get; set; } = [];
    }
}
