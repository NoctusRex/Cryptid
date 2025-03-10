namespace CryptidButFaster.Models
{
    public class Rule
    {
        public required string Id { get; set; }
        public bool Negated { get; set; }
        public int? Range { get; set; }
        public List<Terrains>? Terrains { get; set; }
        public List<Structures>? Structures { get; set; }
        public List<Territories>? Territories { get; set; }
        public StructureColors? StructureColor { get; set; }
    }
}
