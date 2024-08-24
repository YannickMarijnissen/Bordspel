using HerexamenYannickMarijnissen.Models;
using System.Collections.Generic;
using System.Linq;

namespace HerexamenYannickMarijnissen.Data.Repository
{
    public class Repository
    {
        private List<Game> games;

        public Repository()
        {
            games = new List<Game>
        {
            new Game
            {
                Id = 1,
                Name = "Catan",
                Description = "Een strategisch bordspel waar spelers grondstoffen verzamelen en gebruiken om dorpen en steden te bouwen.",
                Players = new List<string> { "2-4 spelers" },
                Duration = "60-120 minuten",
                Difficulty = "Gemiddeld",
                Reviews = new List<string> { "Geweldig spel!", "Zeer verslavend." }
            },
            new Game
            {
                Id = 2,
                Name = "Pandemic",
                Description = "Een coöperatief bordspel waarin spelers samenwerken om de wereld te redden van uitbraken van ziektes.",
                Players = new List<string> { "2-4 spelers" },
                Duration = "45-60 minuten",
                Difficulty = "Makkelijk",
                Reviews = new List<string> { "Een uitdagend spel", "Geweldig om samen te spelen." }
            }
        };
        }

        public List<Game> GetAllGames() => games;

        public void AddGame(Game game)
        {
            game.Id = games.Any() ? games.Max(g => g.Id) + 1 : 1;
            games.Add(game);
        }

        public Game GetGameById(int id) => games.FirstOrDefault(g => g.Id == id);
    }

}
