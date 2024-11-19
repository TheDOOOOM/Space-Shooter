using System;
using System.Collections;
using Boootstrapp.GameFSM;
using Boootstrapp.GameFSM.States;
using GameFSM.States;
using Services;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyInstance : MonoBehaviour
{
    [SerializeField] private BoxCollider2D _spawnArea;
    [SerializeField] private Enemy _enemyRobot;
    [SerializeField] private Enemy _enemyDrone;

    private EnemyColection _enemyColection;
    private GameStateMashine _gameStateMashine;
    private float _destroyDeleay = 10f;
    private int _maxEnemy = 30;

    public void Init()
    {
        _enemyColection = ServiceLocator.Instance.GetService<EnemyColection>();
        _gameStateMashine = ServiceLocator.Instance.GetService<GameStateMashine>();
        StartCoroutine(InstanceEnemy());
    }

    private IEnumerator InstanceEnemy()
    {
        var wait = new WaitForSecondsRealtime(3f);
        while (_maxEnemy > 0)
        {
            InstanceEnemy(_enemyDrone);
            _maxEnemy -= 1;
            yield return wait;
            InstanceEnemy(_enemyRobot);
            _maxEnemy -= 1;
            if (_maxEnemy <= 0)
            {
            }
        }
    }

    public void Update()
    {
        if (_maxEnemy <= 0)
        {
            _destroyDeleay -= Time.deltaTime;
            if (_destroyDeleay <= 0)
            {
                _gameStateMashine.Enter<ComplitedState>();
                Destroy(gameObject);
            }
        }
    }

    private void InstanceEnemy(Enemy enemy)
    {
        Bounds bounds = _spawnArea.bounds;
        float randomX = Random.Range(bounds.min.x, bounds.max.x);
        float randomY = Random.Range(bounds.min.y, bounds.max.y);
        Vector2 spawnPosition = new Vector2(randomX, randomY);
        var instance = Instantiate(enemy, spawnPosition, Quaternion.identity);
        instance.transform.SetParent(transform);
        instance.Init();
        _enemyColection.Add(instance);
    }
}