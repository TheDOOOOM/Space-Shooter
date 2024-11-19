using System;
using UnityEngine;

namespace Boootstrapp.GameFSM.Screens
{
    public class GameElements : MonoBehaviour
    {
        [SerializeField] private GunsCreator _gunsCreator;
        [SerializeField] private EnemyInstance _enemyInstance;


        private void Start()
        {
            Init();
        }

        public void AddGun()
        {
            _gunsCreator.InstanceBye();
        }

        private void Init()
        {
            _enemyInstance.Init();
        }
    }
}