using Boootstrapp.GameFSM.GunsConfigs;
using Configs;
using GameFSM.Screens.ShopScreen;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Boootstrapp.GameFSM.Screens.ShopScreen
{
    public class ShopContent : BaseContent
    {
        [SerializeField] private GunsData _gunsConfigs;
        [SerializeField] private PlayerVallet _playerVallet;
        [SerializeField] private Button _buyButton;
        [SerializeField] private TextMeshProUGUI _textPrice;

        private void OnEnable() => _buyButton.onClick.AddListener(BuyItem);

        public void BuyItem()
        {
            if (!_gunsConfigs.CheckItemUbloc(ItemIndex))
            {
                if (_playerVallet.PlayerCoins >= _gunsConfigs.GetPrice(ItemIndex))
                {
                    _gunsConfigs.UlockItem(ItemIndex);
                    _playerVallet.SaleValue(_gunsConfigs.GetPrice(ItemIndex));
                }
            }
        }

        public void SetNexItem()
        {
            SoundManager.PlayButtonClick();
            NextItem();
            _textPrice.text = $"{_gunsConfigs.GetPrice(ItemIndex)}";
        }

        public void SetBackItem()
        {
            SoundManager.PlayButtonClick();
            BackItem();
            _textPrice.text = $"{_gunsConfigs.GetPrice(ItemIndex)}";
        }


        private void OnDisable() =>
            _buyButton.onClick.AddListener(BuyItem);
    }
}