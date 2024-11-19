using Boootstrapp.Guns;
using Guns;
using UnityEngine;

namespace Boootstrapp.GameFSM.Interfaces
{
    public interface IGunFactory
    {
        public ShootingСannon CreateGun(int itemID, Transform position);
    }
}