using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Boootstrapp.GameFSM.Screens
{
    public class DataVisual : MonoBehaviour
    {
        [SerializeField] private Image[] _images;
        [SerializeField] private TextMeshProUGUI _progressUpdate;
        [SerializeField] private Sprite _upgradeActive;
        [SerializeField] private Sprite _upgradeNon;

        public void SetData(int countLevelUps)
        {
            float progress = (countLevelUps / 5) * 100;


            progress = Mathf.Clamp(progress, 0, 100);
            _progressUpdate.text = $"{progress}";
            for (int i = 0; i < _images.Length; i++)
            {
                if (i < countLevelUps)
                {
                    _images[i].sprite = _upgradeActive;
                }
                else
                {
                    _images[i].sprite = _upgradeNon;
                }
            }
        }
    }
}