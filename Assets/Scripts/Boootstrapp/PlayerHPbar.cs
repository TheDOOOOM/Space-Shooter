using UnityEngine;
using UnityEngine.UI;

public class PlayerHPbar : MonoBehaviour
{
    [SerializeField] private Image _imageBar;

    public void ViewHp(int playerHP, int MaxHp)
    {
        float progress = (float)playerHP / MaxHp;
        progress = Mathf.Clamp01(progress);
        _imageBar.fillAmount = progress;
    }
}