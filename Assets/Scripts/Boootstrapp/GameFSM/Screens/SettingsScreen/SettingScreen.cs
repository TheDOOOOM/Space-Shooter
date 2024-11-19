using Boootstrapp.GameFSM.Screens;
using UnityEngine;

namespace GameFSM.Screens.SettingsScreen
{
    public class SettingScreen : BaseScreen
    {
        [SerializeField] private SwitchImage _switchImageMusick;
        [SerializeField] private SwitchImage _switchImageSound;

        public SwitchImage SwitchImageMusick => _switchImageMusick;
        public SwitchImage SwitchImageSound => _switchImageSound;

        public void SetValueScreen(bool soundValue, bool musickValue)
        {
            _switchImageSound.SetValue(soundValue);
            _switchImageMusick.SetValue(musickValue);
        }

        public void BackMenu()
        {
            SoundManager.PlayButtonClick();
            GameStateMashine.Back();
        }
    }
}