namespace PlayerManagerMVC
{
    /// <summary>
    /// The player listing program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Program begins here.
        /// </summary>
        /// <param name="args">Not used.</param>
        private static void Main()
        {
            // Initialize the player list with two players using collection
            // initialization syntax
            PlayerList playerList = new PlayerList() {
                new Player("Best player ever", 100),
                new Player("An even better player", 500)
            };

            IView view = new UglyView();

            // Instantiate Controller
            Controller controller = new Controller(playerList);

            // Ask the controller to run the program
            controller.Run(view);
        }
    }
}
