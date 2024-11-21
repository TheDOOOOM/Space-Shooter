using System;
using System.Threading;
using Boootstrapp.GameFSM.GunsConfigs;
using Boootstrapp.Services;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class ShotComponent : MonoBehaviour
{
    [SerializeField] private Projectile _projectile;
    [SerializeField] private Transform _shotPoint;
    [SerializeField] private float _shotDelay;

    private PoolObject<Projectile> _poolProjectiles;
    private CancellationTokenSource _cancellationTokenSource;

    public void StartShooting()
    {
        _poolProjectiles = new PoolObject<Projectile>(_projectile);
        if (_cancellationTokenSource != null)
        {
            _cancellationTokenSource.Cancel(); // Останавливаем предыдущий процесс
            _cancellationTokenSource.Dispose();
        }

        _cancellationTokenSource = new CancellationTokenSource();
        Shot(_cancellationTokenSource.Token);
    }


    private async void Shot(CancellationToken cancellationToken)
    {
        var delay = TimeSpan.FromSeconds(_shotDelay);

        while (true)
        {
            // Проверяем, существует ли _shotPoint перед каждым выстрелом
            if (_shotPoint == null)
            {
                Debug.LogWarning("_shotPoint был уничтожен. Прерываем выполнение Shot.");
                return;
            }

            try
            {
                // Ожидание с учётом токена
                await UniTask.Delay(delay, cancellationToken: cancellationToken);
            }
            catch (OperationCanceledException)
            {
                // Обработка отмены
                Debug.Log("Shot был отменён.");
                return;
            }

            if (_shotPoint == null) // Повторная проверка после задержки
            {
                Debug.LogWarning("_shotPoint стал null после ожидания. Прерываем выполнение Shot.");
                return;
            }

            var item = _poolProjectiles.GetItem();
            item.transform.position = _shotPoint.position;
            item.Initialize(_shotPoint.up);
        }
    }

    public void Reset()
    {
        if (_cancellationTokenSource != null)
        {
            _cancellationTokenSource.Cancel(); // Отменяем текущую задачу
            _cancellationTokenSource.Dispose();
            _cancellationTokenSource = null;
        }
    }
}