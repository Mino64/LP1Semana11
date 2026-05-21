
using System.Collections.Generic;

namespace PlayerManagerMVC
{
    public interface IView
    {
        string MainMenu();
        void ExitMessage();
        void BadOption(string msg);
        void WaitForUser();
        (string, int) AskPlayerData();
        void ListPlayers(IEnumerable<Player> playersToList);
        PlayerOrder AskForPlayerOrder();
        int AskForMinScore();
    }
}