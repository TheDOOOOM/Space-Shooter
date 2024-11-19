using Boootstrapp.GameFSM.Screens;
using GameFSM.Screens;

namespace GameFSM.Instarfaces
{
    public interface IFactoryScreen
    {
        public T CreateScreen<T>(BaseScreen screen) where T : BaseScreen;
    }
}