using Boootstrapp;
using Boootstrapp.GameFSM.Screens;
using Boootstrapp.GameFSM.States;
using GameFSM.Screens;
using GameFSM.States;

namespace Screens
{
    public class MenuScreen : BaseScreen
    {
        public void OpenGameScreen()
        {
            GameStateMashine.Enter<GameState>();
            SoundManager.PlayButtonClick();
        }

        public void OpenSettings()
        {
            GameStateMashine.Enter<SettingsState>();
            SoundManager.PlayButtonClick();
        }

        public void OpenCollectionScreen()
        {
            GameStateMashine.Enter<ColectionState>();
            SoundManager.PlayButtonClick();
        }

        public void OpenShopScreen()
        {
            GameStateMashine.Enter<ShopState>();
            SoundManager.PlayButtonClick();
        }
    }
}