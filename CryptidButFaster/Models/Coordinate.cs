namespace CryptidButFaster.Models
{
    public class Coordinate
    {
        public int R { get; set; }
        public int Q { get; set; }

        public override string ToString()
        {
            return $"{Q}-{R}";
        }

        public static Coordinate? FromString(string? coord)
        {
            if (string.IsNullOrEmpty(coord)) return null;

            return new()
            {
                Q = int.Parse(coord.Split('-')[0]),
                R = int.Parse(coord.Split('-')[1])
            };
        }
    }
}
