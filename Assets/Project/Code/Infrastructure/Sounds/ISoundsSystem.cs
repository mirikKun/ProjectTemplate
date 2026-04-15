using UnityEngine;

namespace Code.Infrastructure.Sounds
{
    public interface ISoundsSystem
    {
        void SetMusicVolume(float volume);
        void SetSFXVolume(float volume);
        void SetMasterVolume(float volume);
        float GetMusicVolume();
        float GetSFXVolume();
        float GetMasterVolume();

        void PlaySfx(AudioClip clip, float volumeScale = 1f, float pitch = 1f);
        void PlayMusic(AudioClip clip, bool loop = true, float volumeScale = 1f);
        void StopMusic();
    }
}