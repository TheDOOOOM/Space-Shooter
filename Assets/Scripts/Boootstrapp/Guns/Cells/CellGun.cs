using Boootstrapp.GameFSM.Interfaces;
using Boootstrapp.Guns.Cells;
using UnityEngine;

public class CellGun : BaseCells
{
    private float _counterDelay = 0;

    public override void AssignItem(IDragAndDropItem item)
    {
        base.AssignItem(item);
        _counterDelay = 0;
        item.RotationToEnemy.Active();
    }

    public void Update()
    {
        if (Item == null)
        {
            return;
        }

        _counterDelay += Time.deltaTime;
        if (_counterDelay > Item.Delay)
        {
            Item.Shot();
            _counterDelay = 0;
        }
    }
}