using Boootstrapp.GameFSM.Interfaces;
using UnityEngine;


namespace Boootstrapp.Guns
{
    public abstract class ShootingСannon : MonoBehaviour, IDragAndDropItem
    {
        [SerializeField] protected RotationToEnemy RotationToComponent;
        [SerializeField] private ShotComponent _shotComponent;


        public ShotComponent ShotComponent { get; set; }
        public RotationToEnemy RotationToEnemy { get; set; }
        public Transform MyTransform { get; set; }
        public Vector3 InitialPosition { get; set; }
        public int ItemID { get; set; }
        public float Delay { get; set; }
        private Vector3 _offset = new Vector3(0, 0.19f, 0);

        public void SetId(int id)
        {
            ItemID = id;
            RotationToEnemy = RotationToComponent;
        }

        public void Init()
        {
            MyTransform = transform;
            InitialPosition = transform.position;
            RotationToEnemy = RotationToComponent;
            ShotComponent = _shotComponent;
        }

        public void OnDrag(Vector3 position)
        {
            if (transform != null)
            {
                transform.position = position;
            }
        }

        public void OnDrop(Vector3 position)
        {
            transform.position = position - _offset;
        }
    }
}