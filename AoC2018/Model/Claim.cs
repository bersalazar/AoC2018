namespace Advent2018.Model
{
    public class Claim
    {
        public Claim(string entry)
        {
            var splitInArroba = entry.Split('@');
            Id = splitInArroba[0].Trim(' ', '#');
            PositionX = int.Parse(splitInArroba[1].Split(',')[0].Trim(' '));
            PositionY = int.Parse(entry.Split(':')[0].Split(',')[1]);
            Width = int.Parse(entry.Split('x')[0].Split(':')[1].Trim(' '));
            Height = int.Parse(entry.Split('x')[1].Trim(' '));
        }

        public string Id;
        public int PositionX;
        public int PositionY;
        public int Width;
        public int Height;
        public bool Touched = false;
    }
}