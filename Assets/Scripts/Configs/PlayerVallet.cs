using System;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "PlayerVallet", menuName = "PlayerVallet")]
    public class PlayerVallet : ScriptableObject
    {
        [SerializeField] private int _valueCouns;

        public event Action OnValueCheng;


        public int PlayerCoins => _valueCouns;

        public void Add(int value)
        {
            _valueCouns += value;
            OnValueCheng?.Invoke();
        }

        public void SaleValue(int value)
        {
            _valueCouns -= value;
            OnValueCheng?.Invoke();
        }
    }
}