using UnityEngine;

namespace Boootstrapp.GameFSM.Interfaces
{
    public interface IDragAndDropItem
    {
        public ShotComponent ShotComponent { get; set; }
        public RotationToEnemy RotationToEnemy { get; set; }
        public int ItemID { get; set; }
        Transform MyTransform { get; set; }
        Vector3 InitialPosition { get; set; }
        public void Init();
        void OnDrag(Vector3 position);
        void OnDrop(Vector3 position);
    }
}