using System;
using Boootstrapp.GameFSM.Interfaces;
using Boootstrapp.Services.Factory;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Services;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Boootstrapp.Guns.Cells
{
    public class BaseCells : MonoBehaviour, ICell
    {
        protected IDragAndDropItem Item;
        protected BaseCells CellsType;

        private Vector3 _offset = new Vector3(0, 0.19f, 0);
        public IDragAndDropItem ItemID { get; set; }
        public IDragAndDropItem NexID { get; set; }
        public IGunFactory GunFactory { get; set; }
        public Vector3 Position => transform.position;
        public bool IsOccupied => Item != null;
        private float _radius = 0.7f;
        private float _animationDuratiom = 0.5f;

        public void Start()
        {
            GunFactory = ServiceLocator.Instance.GetService<GunFactory>();
        }

        public IDragAndDropItem RemoveItem()
        {
            var item = Item;
            Item = null;
            ItemID = null;
            return item;
        }

        public ShootingСannon UpdateShootingСannon(IDragAndDropItem item)
        {
            var factoryGun = ServiceLocator.Instance.GetService<GunFactory>();
            var upgradedItem = factoryGun.CreateGun(Item.ItemID + 1, transform);
            return upgradedItem;
        }


        public virtual void AssignItem(IDragAndDropItem item)
        {
            CellsType = this;
            if (item == null) return;
            if (Item == null)
            {
                item.RotationToEnemy.Reset();
                item.ShotComponent.Reset();
                Item = item;
                ItemID = Item;
                Item.RotationToEnemy.Reset();
                Item.OnDrop(Position);
                return;
            }

            if (item.RotationToEnemy.Target != null)
            {
                item.RotationToEnemy.Active();
            }

            if (Item != null && Item.ItemID == item.ItemID)
            {
                MergeItems(item);
            }
        }

        private async void MergeItems(IDragAndDropItem item)
        {
            var delay = TimeSpan.FromSeconds(_animationDuratiom);
            var itemOne = Item;
            var itemTwo = item;
            float angleA = Random.Range(0f, 360f);
            Vector2 positionA = GetPositionOnCircumference(angleA, _radius, transform);
            float angleB = angleA + 180f;
            Vector2 positionB = GetPositionOnCircumference(angleB, _radius, transform);

            itemOne.MyTransform.position = positionA;
            itemTwo.MyTransform.position = positionB;

            itemOne.MyTransform.DOMove(transform.position - _offset, _animationDuratiom).SetEase(Ease.InOutQuad)
                .OnComplete(() => { Destroy(itemOne.MyTransform.gameObject); });

            itemTwo.MyTransform.DOMove(transform.position - _offset, _animationDuratiom).SetEase(Ease.InOutQuad)
                .OnComplete(() => { Destroy(itemTwo.MyTransform.gameObject); });
            await UniTask.Delay(delay);
            var upgradeItem = UpdateShootingСannon(itemOne);
            upgradeItem.Init();
            CellsType.AssignItem(upgradeItem);
            Item = upgradeItem;
            Item.Init();
            ItemID = Item;
            Item.OnDrop(Position);
        }

        private Vector2 GetPositionOnCircumference(float angle, float radius, Transform center)
        {
            float radians = angle * Mathf.Deg2Rad;

            float x = center.position.x + Mathf.Cos(radians) * radius;
            float y = center.position.y + Mathf.Sin(radians) * radius;

            return new Vector2(x, y);
        }
    }
}