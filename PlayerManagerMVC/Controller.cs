using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayerManagerMVC
{
    public class Controller
    {
        private PlayerList players;
        public Controller(PlayerList players)
        {
            this.players = players;
        }

        /// <summary>
        /// Run the player listing program instance
        /// </summary>
        private void Run(IView view)
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
                        ListPlayersWithScoreGreaterThan();
                        break;
                    case "4":
                        SortPlayerList();
                        break;
                    case "0":
                        view.ExitMessage();
                        break;
                    default:
                        view.BadOption("Unknown option!");
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
                    players.Sort(compareByName);
                    break;
                case PlayerOrder.ByNameReverse:
                    players.Sort(compareByNameReverse);
                    break;
                default:
                    view.BadOption("Unknown player order! ");
                    break;
            }
        }
    }


}
}