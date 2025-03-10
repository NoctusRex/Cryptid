namespace CryptidButFaster.Models
{
    public class Coordinate
    {
        public  int Q { get; set; }
        public  int R { get; set; }

        public override string ToString()
        {
            return $"{Q}-{R}";
        }
    }
}
