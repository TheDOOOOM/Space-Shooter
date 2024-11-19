using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "SoundSettings", menuName = "SoundSettings")]
    public class SoundSettings : ScriptableObject
    {
        [SerializeField] private bool _musickActive;
        [SerializeField] private bool _soundActive;

        public bool Musick => _musickActive;
        public bool Sound => _soundActive;

        public void SetValueMusick(bool value)
        {
            _musickActive = value;
        }

        public void SetValueSound(bool value)
        {
            _soundActive = value;
        }
    }
}