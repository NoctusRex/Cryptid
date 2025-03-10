namespace CryptidButFaster.Models
{
    public class BoardPart
    {
        public  string Id { get; set; }
        public  List<BoardTile> Tiles { get; set; }
        public  Coordinate Coordinate { get; set; }
    }
}
