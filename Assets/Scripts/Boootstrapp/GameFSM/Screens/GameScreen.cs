using Boootstrapp.GameFSM.Screens;
using Boootstrapp.GameFSM.States;
using Boootstrapp.Services;
using DragAndDrop;
using Effects;
using Services;
using UnityEngine;
using UnityEngine.UI;

namespace GameFSM.Screens
{
    public class GameScreen : BaseScreen
    {
        [SerializeField] private ParalaxBackground _paralaxBackground;
        [SerializeField] private GameElements _gameElements;
        [SerializeField] private Stub _stubPrefab;
        [SerializeField] private Button _button;

        private GameElements _instanceElements;
        private Stub _stubInstance;
        public GameElements GameElements => _instanceElements;
        private DragAndDropHandler _dragAndDropHandler;
        private DisposeService _disposeService;

        public override void Init()
        {
            base.Init();
            CreateStub();
            _dragAndDropHandler = ServiceLocator.Instance.GetService<DragAndDropHandler>();
            _disposeService = ServiceLocator.Instance.GetService<DisposeService>();
        }

        private void CreateStub()
        {
            _stubInstance = Instantiate(_stubPrefab, transform);
            _stubInstance.ButtonReady.onClick.AddListener(StartGame);
        }

        private void StartGame()
        {
            SoundManager.PlayButtonClick();
            _stubInstance.ButtonReady.onClick.RemoveListener(StartGame);
            Destroy(_stubInstance.gameObject);
            _paralaxBackground.Init();
            CreateElements();
        }

        private void CreateElements()
        {
            _instanceElements = Instantiate(_gameElements);
            _button.onClick.AddListener(_instanceElements.AddGun);
        }

        public void BackToMenu()
        {
            SoundManager.PlayButtonClick();
            GameStateMashine.Enter<MenuState>();
            _disposeService.DisposeActive();
            _button.onClick.RemoveListener(_instanceElements.AddGun);
            Destroy(_instanceElements.gameObject);
        }
    }
}