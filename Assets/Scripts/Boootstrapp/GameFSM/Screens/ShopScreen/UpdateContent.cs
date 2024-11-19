using Configs;
using GameFSM.Screens.ShopScreen;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpdateContent : BaseContent
{
    [SerializeField] private UpgradeConfig _upgradeConfig;
    [SerializeField] private PlayerVallet _playerVallet;
    [SerializeField] private TextMeshProUGUI _price;
    [SerializeField] private Button _buyButton;

    private void OnEnable()
    {
        _buyButton.onClick.AddListener(BuyElement);
    }

    public void SetNexItem()
    {
        SoundManager.PlayButtonClick();
        NextItem();
        if (ItemIndex == 0)
        {
            _price.text = $"{_upgradeConfig.PriceDamage}";
        }

        if (ItemIndex == 1)
        {
            _price.text = $"{_upgradeConfig.PriceAttackSpeed}";
        }

        if (ItemIndex == 2)
        {
            _price.text = $"{_upgradeConfig.PriceHeal}";
        }

        if (ItemIndex == 3)
        {
            _price.text = $"{_upgradeConfig.PriceColisionCount}";
        }
    }

    public void BuyElement()
    {
        SoundManager.PlayButtonClick();
        if (ItemIndex == 0)
        {
            _price.text = $"{_upgradeConfig.PriceDamage}";
            BuyDamage();
        }

        if (ItemIndex == 1)
        {
            _price.text = $"{_upgradeConfig.PriceAttackSpeed}";
            BuyAttackSpeed();
        }

        if (ItemIndex == 2)
        {
            _price.text = $"{_upgradeConfig.PriceHeal}";
            BuyHealph();
        }

        if (ItemIndex == 3)
        {
            _price.text = $"{_upgradeConfig.PriceColisionCount}";
            BuyColision();
        }
    }

    private void BuyDamage()
    {
        if (_playerVallet.PlayerCoins >= _upgradeConfig.PriceDamage)
        {
            _playerVallet.SaleValue(_upgradeConfig.PriceDamage);
            _upgradeConfig.AddDamage();
        }
    }

    private void BuyAttackSpeed()
    {
        if (_playerVallet.PlayerCoins >= _upgradeConfig.PriceAttackSpeed)
        {
            _playerVallet.SaleValue(_upgradeConfig.PriceAttackSpeed);
            _upgradeConfig.AddAttackSpeed();
        }
    }

    private void BuyHealph()
    {
        if (_playerVallet.PlayerCoins >= _upgradeConfig.PriceHeal)
        {
            _playerVallet.SaleValue(_upgradeConfig.PriceHeal);
            _upgradeConfig.AddPlayerHeal();
        }
    }

    private void BuyColision()
    {
        if (_playerVallet.PlayerCoins >= _upgradeConfig.PriceColisionCount)
        {
            _playerVallet.SaleValue(_upgradeConfig.PriceColisionCount);
            _upgradeConfig.AddColisionCount();
        }
    }

    private void OnDisable()
    {
        _buyButton.onClick.RemoveListener(BuyElement);
    }

    public void SetBackItem()
    {
        SoundManager.PlayButtonClick();
        BackItem();
        if (ItemIndex == 0)
        {
            _price.text = $"{_upgradeConfig.PriceDamage}";
        }

        if (ItemIndex == 1)
        {
            _price.text = $"{_upgradeConfig.PriceAttackSpeed}";
        }

        if (ItemIndex == 2)
        {
            _price.text = $"{_upgradeConfig.PriceHeal}";
        }

        if (ItemIndex == 3)
        {
            _price.text = $"{_upgradeConfig.PriceColisionCount}";
        }
    }
}