using System;
using System.Collections.Generic;
using Boootstrapp.GameFSM.GunsConfigs;
using Boootstrapp.GameFSM.Screens;
using Boootstrapp.GameFSM.States;
using GameFSM.States;
using Services;
using UnityEngine;

namespace GameFSM.Screens
{
    public class ColectionScreen : BaseScreen
    {
        [SerializeField] private GunsData _gunsData;
        [SerializeField] private List<DataVisual> _dataVisualsl;

        private void Awake()
        {
            for (int i = 0; i < _dataVisualsl.Count; i++)
            {
                _dataVisualsl[i].SetData(_gunsData.GetCountUpdates(i));
            }
        }

        public void BackMenu()
        {
            SoundManager.PlayButtonClick();
            GameStateMashine.Enter<MenuState>();
        }

        public void OpenSettings()
        {
            SoundManager.PlayButtonClick();
            GameStateMashine.Enter<SettingsState>();
        }
    }
}