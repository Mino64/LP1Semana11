using System.Collections.Generic;

namespace PlayerManagerMVC
{
    public interface IView
    {
        string MainMenu();

        void ExitMessage();

        void ErrorMessage(string msg);

        void WaitForUser();

        (string, int) AskPlayerData();

        void ListPlayers(IEnumerable<Player> playersToList);

        PlayerOrder AskForPlayerOrder();

        int AskForMinScore();
    }
}