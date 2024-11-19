using System;
using Boootstrapp.Guns;
using UnityEngine;

namespace Boootstrapp.GameFSM.GunsConfigs
{
    [CreateAssetMenu(fileName = "GunConfig", menuName = "GunConfig")]
    public class GunConfig : ScriptableObject
    {
        [SerializeField] private int _gunId;
        [SerializeField] private ShootingСannon _prefab;
        [SerializeField] private bool _iUlock;
        [SerializeField] private int _price;
        [SerializeField] private int _updateNumber;
        [SerializeField] private ShotConfig _shotConfig;


        public ShotConfig Config => _shotConfig;

        public int UpdateNumbe => _updateNumber;
        public int ItemID => _gunId;
        public bool IUnlock => _iUlock;
        public int Price => _price;

        public void Unblock()
        {
            _iUlock = true;
        }

        public ShootingСannon GetPrefab()
        {
            return _prefab;
        }
    }

    [Serializable]
    public struct ShotConfig
    {
        [SerializeField] private int _damage;
        [SerializeField] private float _delayShot;

        public int Damage => _damage;
        public float ShotDelay => _delayShot;
    }
}