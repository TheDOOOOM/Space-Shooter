using Boootstrapp.GameFSM.Screens;
using Boootstrapp.GameFSM.States;
using Configs;
using GameFSM.Screens;
using TMPro;
using UnityEngine;
using Random = System.Random;


public class ComplitedScreen : BaseScreen
{
    [SerializeField] private PlayerVallet _playerVallet;
    [SerializeField] private TextMeshProUGUI _coinsResult;

    private void Start()
    {
        var randomCoins = new Random().Next(0, 100);
        _playerVallet.Add(randomCoins);
        _coinsResult.text = $"+{randomCoins}";
    }

    public void NextLevel()
    {
        SoundManager.PlayButtonClick();
        GameStateMashine.Enter<GameState>();
    }

    public void MenuEnter()
    {
        SoundManager.PlayButtonClick();
        GameStateMashine.Enter<MenuState>();
    }
}