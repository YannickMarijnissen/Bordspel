using Microsoft.AspNetCore.Components;
using HerexamenYannickMarijnissen.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HerexamenYannickMarijnissen.ViewModels
{
    public class GameListViewModel : ComponentBase
    {
        public List<Game> Games { get; set; } = new List<Game>
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

        public List<Game> FilteredGames { get; set; } = new List<Game>();
        public string SearchTerm { get; set; }
        public int? SelectedGameId { get; set; } // Houdt de geselecteerde game bij
        public Game NewGame { get; set; } = new Game();

        protected override void OnInitialized()
        {
            FilteredGames = Games; // Initialiseren met hardcoded games
            Console.WriteLine($"Aantal games geladen: {Games.Count}");
            Console.WriteLine($"Aantal gefilterde games bij init: {FilteredGames.Count}");
        }

        public void OnSearchTermChanged(ChangeEventArgs e)
        {
            Console.WriteLine($"SearchTerm gewijzigd naar: {e.Value}");
            SearchTerm = e.Value.ToString();
            FilterGames();
        }

        private void FilterGames()
        {
            if (string.IsNullOrEmpty(SearchTerm))
            {
                FilteredGames = Games;
            }
            else
            {
                FilteredGames = Games
                    .Where(g => g.Name.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }
            Console.WriteLine($"Aantal gefilterde games: {FilteredGames.Count}");
        }

        public async Task AddGameAsync()
        {
            try
            {
                // Verwerken van spelers en recensies
                if (!string.IsNullOrEmpty(NewGame.PlayersAsString))
                {
                    NewGame.Players = NewGame.PlayersAsString.Split(',').Select(p => p.Trim()).ToList();
                }

                if (!string.IsNullOrEmpty(NewGame.ReviewsAsString))
                {
                    NewGame.Reviews = NewGame.ReviewsAsString.Split(',').Select(r => r.Trim()).ToList();
                }

                // Zorg voor een unieke ID
                NewGame.Id = Games.Any() ? Games.Max(g => g.Id) + 1 : 1;

                Games.Add(NewGame); // Voeg de nieuwe game toe
                NewGame = new Game(); // Reset het formulier

                // Filter de games opnieuw
                FilterGames();

                Console.WriteLine("Nieuwe game toegevoegd en lijst vernieuwd.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fout bij het toevoegen van een game: {ex.Message}");
            }
        }


        public void ToggleDetails(int gameId)
        {
            if (SelectedGameId == gameId)
            {
                SelectedGameId = null; // Verberg details als het al geselecteerd is
            }
            else
            {
                SelectedGameId = gameId; // Toon details van de geselecteerde game
            }
        }

        public void ShowList()
        {
            SelectedGameId = null; // Verberg details en toon de lijst
        }
    }
}
