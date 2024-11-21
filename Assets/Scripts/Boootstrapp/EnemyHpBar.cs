using UnityEngine;
using UnityEngine.UI;

public class EnemyHpBar : MonoBehaviour
{
    [SerializeField] private Image _hpBar;

    private int MaxHp = 100;

    public void SetValue(int enemyHp)
    {
        float progress = (float)enemyHp / MaxHp;
        progress = Mathf.Clamp01(progress);
        _hpBar.fillAmount = progress;
    }
}