using Configs;
using TMPro;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    [SerializeField] private PlayerVallet _playerVallet;
    [SerializeField] private TextMeshProUGUI _textMeshProUGUI;

    private void OnEnable() => _playerVallet.OnValueCheng += SetValue;

    private void Start() => SetValue();

    public void SetValue() => _textMeshProUGUI.text = $"{_playerVallet.PlayerCoins}";

    private void OnDisable() => _playerVallet.OnValueCheng -= SetValue;
}