using Scenes.Scripts.Instarfaces;
using Services;
using Services.Factory;
using UnityEngine;

namespace Boootstrapp.GameFSM.States
{
    public class ShopState : IState
    {
        private ShopScreen _prefabScreen;
        private ScreenFactory _screenFactory;

        private ShopScreen _instnceScreen;

        public ShopState(ShopScreen screen)
        {
            _prefabScreen = screen;
        }

        public void Enter()
        {
            _screenFactory = ServiceLocator.Instance.GetService<ScreenFactory>();
            _instnceScreen = _screenFactory.CreateScreen<ShopScreen>(_prefabScreen);
            _instnceScreen.Init();
        }

        public void Exit()
        {
            Object.Destroy(_instnceScreen.gameObject);
        }
    }
}