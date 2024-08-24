namespace HerexamenYannickMarijnissen.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Players { get; set; } = new List<string>();
        public string Duration { get; set; }
        public string Difficulty { get; set; }
        public List<string> Reviews { get; set; } = new List<string>();

        public string PlayersAsString
        {
            get => string.Join(", ", Players);
            set => Players = value.Split(',').Select(p => p.Trim()).ToList();
        }

        public string ReviewsAsString
        {
            get => string.Join(", ", Reviews);
            set => Reviews = value.Split(',').Select(r => r.Trim()).ToList();
        }
    }
}
