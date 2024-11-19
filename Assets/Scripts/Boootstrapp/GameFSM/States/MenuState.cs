using Screens;

namespace Boootstrapp.GameFSM.States
{
    public class MenuState : BaseState<MenuScreen>
    {
        public MenuState(MenuScreen prefab) : base(prefab)
        {
        }

        public override void Enter()
        {
            base.Enter();
            SoundManager.PlayMenuSound();
        }
    }
}