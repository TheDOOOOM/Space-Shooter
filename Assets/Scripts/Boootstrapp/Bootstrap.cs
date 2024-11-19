using Boootstrapp;
using Boootstrapp.GameFSM;
using Boootstrapp.GameFSM.GunsConfigs;
using Configs;
using DragAndDrop;
using GameFSM;
using GameFSM.Screens;
using GameFSM.Screens.SettingsScreen;
using GameFSM.States;
using Screens;
using Services;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private SoundSettings _soundSettings;
    [SerializeField] private Transform _screenInstanceConteiner;
    [SerializeField] private DragAndDropHandler _dragAndDropHandler;
    [SerializeField] private SoundManager _soundManager;

    [Space] [Header("Screens")] [SerializeField]
    private MenuScreen _menuScreen;

    [SerializeField] private SettingScreen _settingScreen;
    [SerializeField] private ColectionScreen _colectionScreen;
    [SerializeField] private ShopScreen _shopScreen;
    [SerializeField] private GameScreen _gameScreen;
    [SerializeField] private GunsData _gunsData;
    [SerializeField] private ComplitedScreen _complitedScreen;
    [SerializeField] private LoseScreen _loseScreen;
    private GameStateMashine _gameStateMashine;

    private void Start()
    {
        Init();
        _gameStateMashine = new GameStateMashine(_screenInstanceConteiner, _soundSettings, _dragAndDropHandler,
            _menuScreen, _settingScreen,
            _colectionScreen, _shopScreen, _gameScreen, _gunsData, _loseScreen, _complitedScreen, _soundManager);
        _gameStateMashine.Enter<RegistrationState>();
    }

    private void Init()
    {
        ServiceLocator.Init();
    }
}