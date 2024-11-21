using Boootstrapp.GameFSM.Interfaces;
using Boootstrapp.Guns.Cells;

public class CellGun : BaseCells
{
    private float _counterDelay = 0;

    public override void AssignItem(IDragAndDropItem item)
    {
        base.AssignItem(item);
        CellsType = this;
        _counterDelay = 0;
        item.RotationToEnemy.Active();
        item.ShotComponent.StartShooting();
    }
}