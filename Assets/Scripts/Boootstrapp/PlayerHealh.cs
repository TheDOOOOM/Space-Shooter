using Boootstrapp.GameFSM;
using Boootstrapp.GameFSM.States;
using Services;
using UnityEngine;

public class PlayerHealh : MonoBehaviour
{
    [SerializeField] private int _playerHeal;
    [SerializeField] private UpgradeConfig _upgradeConfig;
    [SerializeField] private PlayerHPbar _playerHPbar;

    private GameStateMashine _gameStateMashine;

    private int MaxHp;

    public void Start()
    {
        MaxHp = _playerHeal + _upgradeConfig.PlayerHeal;
        _playerHeal = MaxHp;
        _playerHPbar.ViewHp(_playerHeal, MaxHp);
        _gameStateMashine = ServiceLocator.Instance.GetService<GameStateMashine>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Enemy>(out var enemy))
        {
            TakeDamage();
            Destroy(enemy.gameObject);
        }
    }

    private void TakeDamage()
    {
        _playerHeal -= 10;
        _playerHPbar.ViewHp(_playerHeal, MaxHp);
        if (_playerHeal <= 0)
        {
            Dead();
            _playerHPbar.ViewHp(_playerHeal, MaxHp);
        }
    }

    private void Dead()
    {
        _gameStateMashine.Enter<LoseState>();
    }
}