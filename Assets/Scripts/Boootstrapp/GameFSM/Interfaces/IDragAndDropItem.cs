using UnityEngine;

namespace Boootstrapp.GameFSM.Interfaces
{
    public interface IDragAndDropItem : IShotGun
    {
        public RotationToEnemy RotationToEnemy { get; set; }
        public int ItemID { get; set; }
        Transform Transform { get; }
        Vector3 InitialPosition { get; set; }
        void OnDrag(Vector3 position);
        void OnDrop(Vector3 position);
    }

    public interface IShotGun
    {
        public float Delay { get; set; }
        public void Shot();
    }
}