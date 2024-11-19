using Boootstrapp.GameFSM.GunsConfigs;
using Boootstrapp.GameFSM.Interfaces;
using Boootstrapp.Services;
using Services;
using UnityEngine;
using UnityEngine.Serialization;

namespace Boootstrapp.Guns
{
    public abstract class ShootingСannon : MonoBehaviour, IDragAndDropItem
    {
        [FormerlySerializedAs("_projectile")] [SerializeField]
        protected Projectile Projectile;

        [SerializeField] protected RotationToEnemy _rotationToEnemy;
        [SerializeField] private Transform _shotPoint;
        [SerializeField] private float _shotDelay;
        public Transform Transform => transform;
        public Vector3 InitialPosition { get; set; }
        public RotationToEnemy RotationToEnemy { get; set; }
        public int ItemID { get; set; }
        public float Delay { get; set; }
        private Vector3 _offset = new Vector3(0, 0.19f, 0);
        public PoolObject<Projectile> PoolProjectiles;

        public void SetId(int id)
        {
            ItemID = id;
            RotationToEnemy = _rotationToEnemy;
        }

        public void SetData(ShotConfig config)
        {
            _shotDelay = config.ShotDelay;
        }

        public void Init()
        {
            Delay = _shotDelay;
            InitialPosition = transform.position;
            PoolProjectiles = new PoolObject<Projectile>(Projectile);
            var disposeService = ServiceLocator.Instance.GetService<DisposeService>();
            disposeService.AddItem(PoolProjectiles);
            PoolProjectiles.Init();
        }

        public void OnDrag(Vector3 position)
        {
            transform.position = position;
        }

        public void OnDrop(Vector3 position)
        {
            if (PoolProjectiles != null)
                PoolProjectiles.DisposeActivate();

            transform.position = position - _offset;
        }

        public void Shot()
        {
            if (_rotationToEnemy.Target == null)
            {
                return;
            }

            var projectile = PoolProjectiles.GetItem();
            Vector2 direction = _shotPoint.up;
            projectile.Initialize(direction);
            projectile.transform.position = _shotPoint.position;
        }
    }
}