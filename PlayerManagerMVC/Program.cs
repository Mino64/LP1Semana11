using System;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace PlayerManagerMVC
{
    /// <summary>
    /// The player listing program.
    /// </summary>
    public class Program
    {
        /// The list of all players
        private readonly PlayerList playerList;

        // Comparer for comparing player by name (alphabetical order)
        private readonly IComparer<Player> compareByName;

        // Comparer for comparing player by name (reverse alphabetical order)
        private readonly IComparer<Player> compareByNameReverse;
        private IView view;

        /// <summary>
        /// Program begins here.
        /// </summary>
        /// <param name="args">Not used.</param>
        private static void Main()
        {

            IComparer<Player> compareByName = new CompareByName(true);
            IComparer<Player> compareByNameReverse = new CompareByName(false);

            PlayerList playerList = new PlayerList()
            {
                new Player("Best Player ever", 100),
                new Player("An even better player", 500)
            };

            view = new UglyView();
            // Instantiate Controller
            Controller controller = new Controller(playerList);
            // Create a new instance of the player listing program
            Program prog = new Program();
            // Start the program instance
            controller.Run(view);
        }













}
