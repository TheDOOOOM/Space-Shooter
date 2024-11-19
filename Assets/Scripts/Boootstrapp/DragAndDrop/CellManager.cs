using System.Linq;
using Boootstrapp.GameFSM.Interfaces;
using UnityEngine;

namespace DragAndDrop
{
    public class CellManager
    {
        private readonly float _snapDistance;

        public CellManager(float snapDistance)
        {
            _snapDistance = snapDistance;
        }

        public ICell FindClosestCell(Vector3 position)
        {
            ICell[] cells = Object.FindObjectsOfType<MonoBehaviour>().OfType<ICell>().ToArray();
            ICell closestCell = null;
            float closestDistance = float.MaxValue;

            foreach (var cell in cells)
            {
                float distance = Vector3.Distance(position, cell.Position);
                if (distance < closestDistance && distance <= _snapDistance)
                {
                    closestCell = cell;
                    closestDistance = distance;
                }
            }

            return closestCell;
        }
    }
}