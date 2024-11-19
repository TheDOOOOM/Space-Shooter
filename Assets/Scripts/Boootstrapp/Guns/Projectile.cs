using System;
using Boootstrapp.Services;
using UnityEngine;

public class Projectile : MonoBehaviour, IPullItem
{
    [SerializeField] private int _dagame;
    [SerializeField] private Rigidbody2D _rb;

    public int Damage { get; set; }
    private Vector2 _direction;
    public bool IActive { get; set; }
    public event Action<IPullItem> IDisable;

    private float _speed = 5f;
    private float _lifeTime = 10f;

    public void ActiveItem()
    {
        IActive = true;
        gameObject.SetActive(true);
    }

    public void Initialize(Vector2 direction)
    {
        _direction = direction.normalized;

        // Вычисляем угол поворота
        float angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;

        // Компенсируем исходный поворот объекта (например, если он изначально смотрит вверх)
        transform.rotation = Quaternion.Euler(0, 0, angle - 90);
    }

    private void FixedUpdate()
    {
        if (_rb != null)
        {
            _rb.MovePosition(_rb.position + _direction * (_speed * Time.fixedDeltaTime));
        }

        _lifeTime -= Time.fixedDeltaTime;
        if (_lifeTime <= 0)
        {
            _lifeTime = 1000f;
            IDisable?.Invoke(this);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Enemy>(out var enemy))
        {
            enemy.TakeDamage(_dagame);
            IDisable?.Invoke(this);
        }
    }

    public void DisableItem()
    {
        IActive = false;
        gameObject.SetActive(false);
    }
}