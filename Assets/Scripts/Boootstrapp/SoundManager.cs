using Configs;
using UnityEngine;

namespace Boootstrapp
{
    public class SoundManager : MonoBehaviour, IService
    {
        [SerializeField] private SoundSettings _soundSettings;
        [SerializeField] private AudioSource _audioMusickMenu;
        [SerializeField] private AudioSource _audioMusickGame;
        [SerializeField] private AudioSource _click;

        private AudioSource _activeAudioSource;

        public void PlayMenuSound()
        {
            _activeAudioSource?.Stop();
            if (_soundSettings.Musick)
            {
                _audioMusickMenu.Play();
                _activeAudioSource = _audioMusickMenu;
            }
        }

        public void PlayButtonClick()
        {
            if (_soundSettings.Sound)
            {
                _click.Play();
            }
        }

        public void PlayGameSound()
        {
            _activeAudioSource?.Stop();
            if (_soundSettings.Musick)
            {
                _audioMusickGame.Play();
                _activeAudioSource = _audioMusickGame;
            }
        }
    }
}