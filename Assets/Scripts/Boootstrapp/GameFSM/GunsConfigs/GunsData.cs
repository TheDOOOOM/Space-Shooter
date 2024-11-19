using System.Collections.Generic;
using UnityEngine;

namespace Boootstrapp.GameFSM.GunsConfigs
{
    [CreateAssetMenu(fileName = "Configs", menuName = "GunsConfigs")]
    public class GunsData : ScriptableObject
    {
        [SerializeField] private List<GunConfig> _gunsConfigs;


        public void UlockItem(int indexItem)
        {
            _gunsConfigs[indexItem].Unblock();
        }

        public int GetCountUpdates(int itemIndex)
        {
            return _gunsConfigs[itemIndex].UpdateNumbe;
        }

        public bool CheckItemUbloc(int itemIndex)
        {
            return _gunsConfigs[itemIndex].IUnlock;
        }

        public int GetPrice(int itemIndex)
        {
            return _gunsConfigs[itemIndex].Price;
        }

        public GunConfig GetGunsConfig(int itemIndex)
        {
            foreach (var gunItem in _gunsConfigs)
            {
                if (gunItem.ItemID == itemIndex && gunItem.IUnlock)
                {
                    return gunItem;
                }
            }

            return null;
        }
    }
}