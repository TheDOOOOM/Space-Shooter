using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Effects
{
    public class ParalaxBackground : MonoBehaviour
    {
        [SerializeField] private RawImage _background;
        [SerializeField] private float _delay;
        [SerializeField] private float _step;

        private CancellationToken _cancellationToken = new();

        private Vector2 _size = new Vector2(1, 1);
        private Vector2 _position = new Vector2(1, 0);
        private float _value;
        private bool _move = false;

        public void Init()
        {
            _move = true;
            MoveBackground();
        }

        private async void MoveBackground()
        {
            _value = Math.Clamp(_value, 0, 1);
            while (_move && _background != null)
            {
                ResetValue(_value);
                _value += _step;
                _position.y = _value;
                _background.uvRect = new Rect(_position, _size);
                await UniTask.WaitForFixedUpdate(_cancellationToken);
            }
        }

        private void ResetValue(float value)
        {
            if (value >= 1) _value = 0;
        }
    }
}