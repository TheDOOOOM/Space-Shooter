using Configs;
using GameFSM.Screens.SettingsScreen;

namespace Boootstrapp.GameFSM.States
{
    public class SettingsState : BaseState<SettingScreen>
    {
        private SoundSettings _soundSettings;

        public SettingsState(SettingScreen settingScreen, SoundSettings soundSettings) : base(settingScreen)
        {
            _soundSettings = soundSettings;
        }

        public override void Enter()
        {
            base.Enter();
            ScreenInit();
        }

        private void ScreenInit()
        {
            InstanceScreen.SetValueScreen(_soundSettings.Sound, _soundSettings.Musick);
            InstanceScreen.SwitchImageMusick.Button.onClick.AddListener(SetValueMusick);
            InstanceScreen.SwitchImageSound.Button.onClick.AddListener(SetValueSound);
        }

        private void SetValueSound()
        {
            _soundSettings.SetValueSound(InstanceScreen.SwitchImageSound.Result);
        }


        private void SetValueMusick() => _soundSettings.SetValueMusick(InstanceScreen.SwitchImageMusick.Result);


        public override void Exit()
        {
            InstanceScreen.SwitchImageMusick.Button.onClick.RemoveListener(SetValueMusick);
            InstanceScreen.SwitchImageSound.Button.onClick.RemoveListener(SetValueSound);
            base.Exit();
        }
    }
}