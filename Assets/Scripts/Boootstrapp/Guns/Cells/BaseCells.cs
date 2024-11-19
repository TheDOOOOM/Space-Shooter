using Boootstrapp.GameFSM.Interfaces;
using Boootstrapp.Services.Factory;
using DG.Tweening;
using Services;
using UnityEngine;

namespace Boootstrapp.Guns.Cells
{
    public class BaseCells : MonoBehaviour, ICell
    {
        protected IDragAndDropItem Item;

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
            upgradedItem.Init();
            Destroy(Item.Transform.gameObject);
            Destroy(item.Transform.gameObject);
            return upgradedItem;
        }


        public virtual void AssignItem(IDragAndDropItem item)
        {
            if (item == null) return;
            if (Item == null)
            {
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
                float angleA = Random.Range(0f, 360f);
                Vector2 positionA = GetPositionOnCircumference(angleA, _radius, transform);
                float angleB = angleA + 180f;
                Vector2 positionB = GetPositionOnCircumference(angleB, _radius, transform);

                Item.Transform.position = positionA;
                item.Transform.position = positionB;

                Item.Transform.DOMove(transform.position - _offset, _animationDuratiom).SetEase(Ease.InOutQuad)
                    .OnComplete(() => { Destroy(Item.Transform.gameObject); });

                item.Transform.DOMove(transform.position - _offset, _animationDuratiom).SetEase(Ease.InOutQuad)
                    .OnComplete(
                        () =>
                        {
                            var upgradeItem = UpdateShootingСannon(item);
                            if (Item.RotationToEnemy.Target != null)
                            {
                                upgradeItem.RotationToEnemy.Active();
                            }

                            Item = upgradeItem;
                            ItemID = Item;
                            Item.OnDrop(Position);
                            Destroy(item.Transform.gameObject);
                        });
            }
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