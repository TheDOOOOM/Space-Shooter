using Boootstrapp.GameFSM.Screens;
using GameFSM.Instarfaces;
using GameFSM.Screens;
using UnityEngine;

namespace Services.Factory
{
    public class ScreenFactory : IFactoryScreen, IService
    {
        private Transform _instanceConteiner;
        private IFactoryScreen _factoryScreenImplementation;

        public ScreenFactory(Transform instanceConteiner)
        {
            _instanceConteiner = instanceConteiner;
        }

        public T CreateScreen<T>(BaseScreen screen) where T : BaseScreen
        {
            var instanceScreen = Object.Instantiate(screen, _instanceConteiner);
            return (T)instanceScreen;
        }
    }
}