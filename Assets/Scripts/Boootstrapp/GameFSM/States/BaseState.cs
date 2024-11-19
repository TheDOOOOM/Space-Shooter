using Boootstrapp.GameFSM.Screens;
using GameFSM.Screens;
using Scenes.Scripts.Instarfaces;
using Services;
using Services.Factory;
using UnityEngine;

namespace Boootstrapp.GameFSM.States
{
    public abstract class BaseState<TScreen> : IState where TScreen : BaseScreen
    {
        protected TScreen ScreenPrefab;
        protected ScreenFactory ScreenFactory;
        protected TScreen InstanceScreen;
        protected SoundManager SoundManager;

        public BaseState(TScreen prefab)
        {
            ScreenPrefab = prefab;
        }

        public virtual void Enter()
        {
            ScreenFactory = ServiceLocator.Instance.GetService<ScreenFactory>();
            SoundManager = ServiceLocator.Instance.GetService<SoundManager>();
            InstanceScreen = ScreenFactory.CreateScreen<TScreen>(ScreenPrefab);
            InstanceScreen.Init();
        }

        public virtual void Exit()
        {
            Object.Destroy(InstanceScreen.gameObject);
        }
    }
}