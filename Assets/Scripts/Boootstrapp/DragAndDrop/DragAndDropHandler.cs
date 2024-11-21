using System.Linq;
using Boootstrapp.GameFSM.Interfaces;
using UnityEngine;

namespace DragAndDrop
{
    public class DragAndDropHandler : MonoBehaviour, IService
    {
        [SerializeField] private Camera _mainCamera;
        [SerializeField] private float _snapDistance = 1f;

        private IDragAndDropItem _currentItem;
        private ICell _originCell;

        private void Update()
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                Vector3 touchPosition = GetWorldPosition(touch.position);

                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        StartDragging(touchPosition);
                        break;
                    case TouchPhase.Moved:
                        ContinueDragging(touchPosition);
                        break;
                    case TouchPhase.Ended:
                        StopDragging(touchPosition);
                        break;
                }
            }
        }

        private Vector3 GetWorldPosition(Vector2 screenPosition)
        {
            Vector3 worldPosition = _mainCamera.ScreenToWorldPoint(screenPosition);
            worldPosition.z = 0;
            return worldPosition;
        }

        private void StartDragging(Vector3 touchPosition)
        {
            RaycastHit2D hit = Physics2D.Raycast(touchPosition, Vector2.zero);
            if (hit.collider != null)
            {
                var item = hit.collider.GetComponent<ICell>();
                if (item != null)
                {
                    _currentItem = item.RemoveItem();
                    _originCell = item;
                }
            }
        }

        private void ContinueDragging(Vector3 touchPosition)
        {
            if (_currentItem != null)
            {
                _currentItem.OnDrag(touchPosition);
            }
        }

        private void StopDragging(Vector3 touchPosition)
        {
            if (_currentItem == null) return;

            ICell closestCell = FindClosestCell(touchPosition);

            if (closestCell != null)
            {
                if (!closestCell.IsOccupied)
                {
                    closestCell.AssignItem(_currentItem);
                    return;
                }

                if (closestCell.IsOccupied && closestCell.ItemID.ItemID == _currentItem.ItemID)
                {
                    closestCell.AssignItem(_currentItem);
                }
                else
                {
                    _originCell?.AssignItem(_currentItem);
                }
            }
            else
            {
                _originCell?.AssignItem(_currentItem);
            }


            _currentItem = null;
            _originCell = null;
        }

        private ICell FindClosestCell(Vector3 position)
        {
            ICell[] cells = FindObjectsOfType<MonoBehaviour>().OfType<ICell>().ToArray();
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