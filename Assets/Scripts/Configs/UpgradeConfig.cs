using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Upgrade", menuName = "Upgrade")]
public class UpgradeConfig : ScriptableObject
{
    [SerializeField] private UpgradeData _upgradeData;
    public int PriceDamage;
    public int PriceAttackSpeed;
    public int PriceColisionCount;
    public int PriceHeal;


    public int DamageBust => _upgradeData.DamageBust;
    public int PlayerHeal => _upgradeData.PlayerHeal;
    public float AtackSpeed => _upgradeData.AtackSpeed;
    public int СolisionCount => _upgradeData.СolisionCount;

    public void AddAttackSpeed()
    {
        _upgradeData.AddAtackSpeed();
    }

    public void AddDamage()
    {
        _upgradeData.AddAtackDamageBust();
    }

    public void AddColisionCount()
    {
        _upgradeData.AddColisionCount();
    }

    public void AddPlayerHeal()
    {
        _upgradeData.AddPlayerHeal();
    }
}

[Serializable]
public struct UpgradeData
{
    [SerializeField] private int _maxAddDamage;
    [SerializeField] private int _maxPlayerHeal;
    [SerializeField] private float _maxAddAtackSpeed;
    [SerializeField] private int _colisionCountMax;

    private int _damageBust;
    private int _playerHeal;
    private float _atackSpeed;
    private int _colisionCount;

    public int DamageBust => _damageBust;
    public int PlayerHeal => _playerHeal;
    public float AtackSpeed => _atackSpeed;
    public int СolisionCount => _colisionCount;

    public void AddAtackSpeed()
    {
        if (!Mathf.Approximately(_atackSpeed, _maxAddAtackSpeed))
        {
            _atackSpeed += 0.0001f;
        }
    }

    public void AddPlayerHeal()
    {
        if (!Mathf.Approximately(_playerHeal, _maxPlayerHeal))
        {
            _playerHeal += 30;
        }
    }

    public void AddAtackDamageBust()
    {
        if (!Mathf.Approximately(_damageBust, _maxAddDamage))
        {
            _damageBust += 10;
        }
    }

    public void AddColisionCount()
    {
        if (!Mathf.Approximately(_damageBust, _maxAddDamage))
        {
            _colisionCount += 1;
        }
    }
}