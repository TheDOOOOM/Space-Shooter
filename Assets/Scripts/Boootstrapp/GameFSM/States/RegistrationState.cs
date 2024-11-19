using System.Collections.Generic;
using System.Linq;
using Boootstrapp;
using Boootstrapp.GameFSM;
using Boootstrapp.GameFSM.GunsConfigs;
using Boootstrapp.GameFSM.States;
using Boootstrapp.Services;
using Boootstrapp.Services.Factory;
using DragAndDrop;
using Scenes.Scripts.Instarfaces;
using Services;
using Services.Factory;
using UnityEngine;

namespace GameFSM.States
{
    public class RegistrationState : IState
    {
        private GameStateMashine _gameFsm;
        private ScreenFactory _screenFactory;
        private DragAndDropHandler _dragAndDropHandler;
        private GunFactory _gunFactory;
        private DisposeService _disposeService = new DisposeService();
        private EnemyColection _enemyColection = new EnemyColection();
        private SoundManager _soundManager;

        public RegistrationState(GameStateMashine gameStateMashine, Transform screenInstanceConteiner,
            DragAndDropHandler dragAndDropHandler, GunsData gunConfig, SoundManager soundManager)
        {
            _gameFsm = gameStateMashine;
            _screenFactory = new ScreenFactory(screenInstanceConteiner);
            _dragAndDropHandler = dragAndDropHandler;
            _gunFactory = new GunFactory(gunConfig);
            _soundManager = soundManager;
        }

        public void Enter()
        {
            RegisterServices();
            _gameFsm.Enter<MenuState>();
        }

        private void RegisterServices()
        {
            ServiceLocator.Instance.AddService(_gameFsm);
            ServiceLocator.Instance.AddService(_screenFactory);
            ServiceLocator.Instance.AddService(_dragAndDropHandler);
            ServiceLocator.Instance.AddService(_gunFactory);
            ServiceLocator.Instance.AddService(_disposeService);
            ServiceLocator.Instance.AddService(_enemyColection);
            ServiceLocator.Instance.AddService(_soundManager);
        }

        public void Exit()
        {
        }
    }

    internal class EnemyColection : IService
    {
        private List<Enemy> _list = new List<Enemy>();

        public void Add(Enemy enemy)
        {
            if (enemy != null)
            {
                _list.Add(enemy);
            }
        }

        public Enemy GetClosestEnemy(Vector3 targetPosition)
        {
            if (_list.Count == 0) return null;

            Enemy closestEnemy = null;
            float minDistance = float.MaxValue;

            foreach (var enemy in _list)
            {
                if (enemy == null || enemy.IsTargeted) continue;

                float distance = Vector3.Distance(enemy.transform.position, targetPosition);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestEnemy = enemy;
                }
            }

            return closestEnemy;
        }
    }
}