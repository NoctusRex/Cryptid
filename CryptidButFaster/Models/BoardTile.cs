namespace CryptidButFaster.Models
{
    public class BoardTile
    {
        public Terrains Terrain { get; set; }
        public Structure? Structure { get; set; }
        public Territories? Territory { get; set; }
        public Coordinate Coordinate { get; set; }
    }
}
