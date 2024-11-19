using Boootstrapp.GameFSM.GunsConfigs;
using Boootstrapp.GameFSM.Interfaces;
using Boootstrapp.Guns;
using Guns;
using UnityEngine;

namespace Boootstrapp.Services.Factory
{
    public class GunFactory : IGunFactory, IService
    {
        private GunsData _gunsData;
        private readonly Vector3 _positionOffset = new Vector3(0, 0.19f, 0);
        private int _maxItemx = 5;

        public GunFactory(GunsData gunsData)
        {
            _gunsData = gunsData;
        }

        public ShootingСannon CreateGun(int itemID, Transform transform)
        {
            itemID = Mathf.Clamp(itemID, 0, _maxItemx);
            var createItem = _gunsData.GetGunsConfig(itemID);
            if (createItem != null)
            {
                var instanceItem = Object.Instantiate(createItem.GetPrefab(), transform);
                instanceItem.transform.position = transform.position - _positionOffset;
                instanceItem.SetId(itemID);
                instanceItem.SetData(createItem.Config);
                return instanceItem;
            }

            return null;
        }
    }
}