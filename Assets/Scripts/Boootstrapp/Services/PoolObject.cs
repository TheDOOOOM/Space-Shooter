using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Boootstrapp.Services
{
    public class PoolObject<T> : IDisposibleItem where T : MonoBehaviour, IPullItem
    {
        private List<T> _objects = new List<T>();
        private readonly T _prefabObject;
        private int _defaultInstanceItems = 3;

        public PoolObject(T objectPreefab)
        {
            _prefabObject = objectPreefab;
        }

        public void Init()
        {
        }

        public T GetItem()
        {
            foreach (var gameObject in _objects)
            {
                if (!gameObject.IActive)
                {
                    gameObject.ActiveItem();
                    return gameObject;
                }
            }

            var instanceItem = Object.Instantiate(_prefabObject);
            instanceItem.IDisable += ResetItem;
            instanceItem.ActiveItem();
            _objects.Add(instanceItem);
            return instanceItem;
        }

        public void ResetItem(IPullItem item)
        {
            item.DisableItem();
        }

        public void DisposeActivate()
        {
            foreach (var item in _objects)
            {
                Object.Destroy(item.gameObject);
                Debug.Log("Унечтожены");
            }

            _objects = new List<T>();
        }
    }

    public interface IPullItem
    {
        public bool IActive { get; set; }
        public event Action<IPullItem> IDisable;
        public void ActiveItem();
        public void DisableItem();
    }
}