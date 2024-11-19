using GameFSM.Screens;
using UnityEngine;

namespace Boootstrapp.GameFSM.States
{
    public class GameState : BaseState<GameScreen>
    {
        public GameState(GameScreen prefab) : base(prefab)
        {
        }

        public override void Enter()
        {
            base.Enter();
            SoundManager.PlayGameSound();
        }

        public override void Exit()
        {
            Object.Destroy(InstanceScreen.GameElements.gameObject);
            base.Exit();
        }
    }
}