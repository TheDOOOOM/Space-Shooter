using System;
using System.Collections.Generic;
using Boootstrapp.GameFSM.GunsConfigs;
using Boootstrapp.GameFSM.States;
using Configs;
using DragAndDrop;
using GameFSM.Screens;
using GameFSM.Screens.SettingsScreen;
using GameFSM.States;
using Scenes.Scripts.Instarfaces;
using Screens;
using UnityEngine;

namespace Boootstrapp.GameFSM
{
    public class GameStateMashine : IService
    {
        private Dictionary<Type, IState> _states;
        private IState _activeState;
        private IState _backState;

        public GameStateMashine
        (Transform screenInstanceConteiner,
            SoundSettings soundSettings,
            DragAndDropHandler dropHandler,
            MenuScreen menuScreen,
            SettingScreen settingScreen,
            ColectionScreen colectionScreen,
            ShopScreen shopScreen,
            GameScreen gameScreen,
            GunsData gunsData,
            LoseScreen loseScreen,
            ComplitedScreen complitedScreen,
            SoundManager soundManager
        )
        {
            _states = new Dictionary<Type, IState>()
            {
                [typeof(RegistrationState)] =
                    new RegistrationState(this, screenInstanceConteiner, dropHandler, gunsData, soundManager),
                [typeof(MenuState)] = new MenuState(menuScreen),
                [typeof(SettingsState)] = new SettingsState(settingScreen, soundSettings),
                [typeof(ColectionState)] = new ColectionState(colectionScreen),
                [typeof(ShopState)] = new ShopState(shopScreen),
                [typeof(GameState)] = new GameState(gameScreen),
                [typeof(LoseState)] = new LoseState(loseScreen),
                [typeof(ComplitedState)] = new ComplitedState(complitedScreen)
            };
        }

        public void Enter<TState>()
        {
            _activeState?.Exit();
            _backState = _activeState;
            _activeState = _states[typeof(TState)];
            _activeState.Enter();
        }

        public void Back()
        {
            if (_backState != null)
            {
                _activeState?.Exit();
                _activeState = _backState;
                _backState = null;
                _activeState.Enter();
            }
        }
    }
}