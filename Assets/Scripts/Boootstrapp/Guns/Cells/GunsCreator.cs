using System.Linq;
using Boootstrapp.Services.Factory;
using Configs;
using Services;
using Services.Factory;
using UnityEngine;

public class GunsCreator : MonoBehaviour
{
    [SerializeField] private CellInstance[] _cellsInstance;
    [SerializeField] private CellGun[] _cellsGunInstance;
    [SerializeField] private PlayerVallet _playerVallet;

    private GunFactory _gunFactory;
    private int _priceCreator = 50;

    private void Awake() => _gunFactory = ServiceLocator.Instance.GetService<GunFactory>();

    private void Start() => ActiveGunCells();

    private void ActiveGunCells()
    {
        for (int i = 0; i < _cellsGunInstance.Length; i++)
        {
            var itemInstance = _gunFactory.CreateGun(0, _cellsGunInstance[i].transform);
            itemInstance.Init();
            _cellsGunInstance[i].AssignItem(itemInstance);
        }
    }

    public void InstanceBye()
    {
        var nonOccupiedCell = GetNonOccupiedCell();

        if (nonOccupiedCell != null && _playerVallet.PlayerCoins >= _priceCreator)
        {
            var itemInstance = _gunFactory.CreateGun(0, nonOccupiedCell.transform);
            nonOccupiedCell.AssignItem(itemInstance);
            _playerVallet.SaleValue(_priceCreator);
        }
    }

    private CellInstance GetNonOccupiedCell()
    {
        var shuffledCells = _cellsInstance.OrderBy(_ => UnityEngine.Random.value).ToArray();
        foreach (var cell in shuffledCells)
        {
            if (!cell.IsOccupied)
            {
                return cell;
            }
        }

        return null;
    }
}