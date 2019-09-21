using UnityEngine;

namespace FireCloud.Managers
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance;
        public AudioSource _sfxAudioSource;


        private void OnEnable()
        {
            if(Instance != null)
            {
                return;
            }
            Instance = this;
        }

        public void PlaySFX(AudioClip sfx)
        {
            if(Instance != null)
            {
                _sfxAudioSource.clip = sfx;
                _sfxAudioSource.Play();
            }
        }
    }
}
