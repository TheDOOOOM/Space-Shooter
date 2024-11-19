using System;
using System.Collections;
using Configs;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private BoxCollider2D _collider;
    [SerializeField] private int _hp;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite _spriteDead;
    [SerializeField] private Sprite _active;
    [SerializeField] private EnemyHpBar _enemyHp;
    [SerializeField] private PlayerVallet _playerVallet;

    private float _speed = 0.5f;

    public bool IActive = false;

    public bool IsTargeted = false;

    public void Init()
    {
        _spriteRenderer.sprite = _active;
        _collider.enabled = true;
        IActive = true;
        IsTargeted = false;
    }


    public void TakeDamage(int damage)
    {
        _hp -= damage;
        _enemyHp.SetValue(_hp);
        if (_hp <= 0)
        {
            Dead();
        }
    }

    public void Update()
    {
        Move();
    }


    private void Move()
    {
        transform.position += new Vector3(0, _speed * Time.deltaTime * -1, 0);
    }

    private void Dead()
    {
        IActive = false;
        StartCoroutine(DeadActive());
    }

    private IEnumerator DeadActive()
    {
        var delay = new WaitForSecondsRealtime(0.3f);
        while (true)
        {
            _collider.enabled = false;
            _enemyHp.gameObject.SetActive(false);
            _spriteRenderer.sprite = _spriteDead;
            yield return delay;
            _playerVallet.Add(15);
            Destroy(gameObject);
        }
    }
}