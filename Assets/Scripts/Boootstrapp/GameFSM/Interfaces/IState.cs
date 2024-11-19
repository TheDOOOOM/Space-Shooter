namespace Scenes.Scripts.Instarfaces
{
    public interface IState : IStateEnter, IStateExit
    {
    }

    public interface IStateEnter
    {
        public void Enter();
    }

    public interface IStateExit
    {
        public void Exit();
    }
}