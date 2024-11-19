using Boootstrapp.GameFSM.Screens;
using Boootstrapp.GameFSM.States;
using GameFSM.Screens;

public class LoseScreen : BaseScreen
{
    public void Restart()
    {
        GameStateMashine.Enter<GameState>();
    }

    public void MenuOpen()
    {
        GameStateMashine.Enter<MenuState>();
    }
}