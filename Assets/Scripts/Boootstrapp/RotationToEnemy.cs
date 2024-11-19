using System;
using GameFSM.States;
using Services;
using UnityEngine;

public class RotationToEnemy : MonoBehaviour
{
    [NonSerialized] public Enemy Target;

    private EnemyColection _enemyCollection;
    private bool _IsHshut = false;

    private void Awake()
    {
        _enemyCollection = ServiceLocator.Instance.GetService<EnemyColection>();
    }

    public void Active()
    {
        _IsHshut = true;
    }

    public void Reset()
    {
        _IsHshut = false;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        Target = null;
    }

    private void Update()
    {
        if (!_IsHshut)
        {
            return;
        }

        if (Target == null || !Target.gameObject.activeInHierarchy)
        {
            FindNewTarget();
        }

        if (Target != null)
        {
            RotateTowardsTarget();
        }
    }

    private void FindNewTarget()
    {
        Target = _enemyCollection.GetClosestEnemy(transform.position);

        if (Target != null)
        {
            Target.IsTargeted = true; // Помечаем врага как цель
        }
    }

    private void RotateTowardsTarget()
    {
        // Вычисляем направление к цели
        Vector2 direction = (Target.transform.position - transform.position).normalized;

        // Вычисляем угол поворота относительно оси Z
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Устанавливаем новый поворот объекта
        transform.rotation = Quaternion.Euler(0, 0, angle - 90);
    }
}