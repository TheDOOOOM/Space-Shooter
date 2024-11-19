using System;
using Boootstrapp;
using Services;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace GameFSM.Screens.ShopScreen
{
    public class BaseContent : MonoBehaviour
    {
        [SerializeField] protected GameObject[] _shopItems;
        [SerializeField] protected Button _buttonOpenShop;
        [SerializeField] protected Button _buttonOpenUpdate;
        [SerializeField] protected Button _activeNextItemButton;
        [SerializeField] protected Button _aciteveBackButtonItem;
        [SerializeField] private Transform _instanceConteiner;

        public Button ButtonShop => _buttonOpenShop;
        public Button ButtonUpdate => _buttonOpenUpdate;

        protected SoundManager SoundManager;

        protected int ItemIndex = 0;

        protected GameObject _instanceGameObject;

        public virtual void Init()
        {
            ApproveIndex();
            CreateItem(_shopItems[ItemIndex]);
            SoundManager = ServiceLocator.Instance.GetService<SoundManager>();
        }

        protected void NextItem()
        {
            ItemIndex++;
            SwitchItem();
        }

        protected void BackItem()
        {
            ItemIndex--;
            SwitchItem();
        }

        private void SwitchItem()
        {
            ApproveIndex();
            if (_instanceGameObject != null)
            {
                Destroy(_instanceGameObject.gameObject);
                CreateItem(_shopItems[ItemIndex]);
                return;
            }

            CreateItem(_shopItems[ItemIndex]);
        }

        private void CreateItem(GameObject item)
        {
            _instanceGameObject = Instantiate(item, _instanceConteiner);
        }

        private void ApproveIndex()
        {
            ItemIndex = Math.Clamp(ItemIndex, 0, _shopItems.Length - 1);
            ChangeButtonsActiveState(ItemIndex);
        }

        private void ChangeButtonsActiveState(int value)
        {
            _aciteveBackButtonItem.gameObject.SetActive(value != 0);
            _activeNextItemButton.gameObject.SetActive(value != _shopItems.Length - 1);
        }
    }
}