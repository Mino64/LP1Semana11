using System.Collections.Generic;

namespace PlayerManagerMVC
{
    /// <summary>
    /// This class represents the concept of a Controller in the MVC pattern.
    /// </summary>
    public class Controller
    {
        // The player list (part of the Model)
        private readonly PlayerList players;

        public Controller(PlayerList players)
        {
            // Keep the player list (part of the model)
            this.players = players;
        }

        /// <summary>
        /// Run the player listing program instance
        /// </summary>
        public void Run(IView view)
        {
            // We keep the user's option here
            string option;

            // Main program loop
            do
            {
                // Show menu and get user option
                option = view.MainMenu();

                // Determine the option specified by the user and act on it
                switch (option)
                {
                    case "1":
                        // Insert player
                        (string name, int score) = view.AskPlayerData();
                        players.Add(new Player(name, score));
                        break;
                    case "2":
                        view.ListPlayers(players);
                        break;
                    case "3":
                        ListPlayersWithScoreGreaterThan(view);
                        break;
                    case "4":
                        SortPlayerList(view);
                        break;
                    case "0":
                        view.ExitMessage();
                        break;
                    default:
                        view.ErrorMessage("Unknown option!");
                        break;
                }

                view.WaitForUser();

                // Loop keeps going until players choses to quit (option 4)
            } while (option != "0");
        }

        /// <summary>
        /// Show all players with a score higher than a user-specified value.
        /// </summary>
        private void ListPlayersWithScoreGreaterThan(IView view)
        {
            // Minimum score user should have in order to be shown
            int minScore;
            // Enumerable of players with score higher than the minimum score
            IEnumerable<Player> playersWithScoreGreaterThan;

            minScore = view.AskForMinScore();

            // Get players with score higher than the user-specified value
            playersWithScoreGreaterThan = players.GetPlayersWithScoreGreaterThan(minScore);

            // List all players with score higher than the user-specified value
            view.ListPlayers(playersWithScoreGreaterThan);
        }

        /// <summary>
        ///  Sort player list by the order specified by the user.
        /// </summary>
        private void SortPlayerList(IView view)
        {
            PlayerOrder playerOrder = view.AskForPlayerOrder();

            switch (playerOrder)
            {
                case PlayerOrder.ByScore:
                    players.Sort();
                    break;
                case PlayerOrder.ByName:
                    players.SortByName();
                    break;
                case PlayerOrder.ByNameReverse:
                    players.SortByNameReverse();
                    break;
                default:
                    view.ErrorMessage("Unknown player order!");
                    break;
            }
        }

    }
}