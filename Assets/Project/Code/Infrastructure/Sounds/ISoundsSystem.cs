
namespace Code.Infrastructure.Sounds
{
    public  interface ISoundsSystem
    {

        void SetMusicVolume(float volume);
        void SetSFXVolume(float volume);
        void SetMasterVolume(float volume);
        float GetMusicVolume();
        float GetSFXVolume();
        float GetMasterVolume();
    }
}