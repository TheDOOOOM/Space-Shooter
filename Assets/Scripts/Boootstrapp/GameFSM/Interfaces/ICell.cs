using Boootstrapp.Guns;
using Guns;
using UnityEngine;

namespace Boootstrapp.GameFSM.Interfaces
{
    public interface ICell
    {
        public IDragAndDropItem ItemID { get; set; }
        public IDragAndDropItem NexID { get; set; }
        public IGunFactory GunFactory { get; set; }
        Vector3 Position { get; }
        bool IsOccupied { get; }
        void AssignItem(IDragAndDropItem item);
        IDragAndDropItem RemoveItem();
        public ShootingСannon UpdateShootingСannon(IDragAndDropItem item);
    }
}