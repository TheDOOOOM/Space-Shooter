using Services;
using UnityEngine;

namespace Boootstrapp.GameFSM.Screens
{
    public class BaseScreen : MonoBehaviour
    {
        protected GameStateMashine GameStateMashine;
        protected SoundManager SoundManager;

        public virtual void Init()
        {
            GameStateMashine = ServiceLocator.Instance.GetService<GameStateMashine>();
            SoundManager = ServiceLocator.Instance.GetService<SoundManager>();
        }
    }
}