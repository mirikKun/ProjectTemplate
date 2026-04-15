using Code.Infrastructure.StaticData;
using Zenject;

namespace Code.Infrastructure.Sounds
{
    public class SoundsSystem : ISoundsSystem
    {
        private IStaticDataService _staticDataService;

        [Inject]
        private void Construct(IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
        }

        public void SetMusicVolume(float volume)
        {
            
        }
        
        public void SetSFXVolume(float volume)
        {

        }
        
        public void SetMasterVolume(float volume)
        {

            
        }
        
        public float GetMusicVolume()
        {

            return 1f;
        }
        
        public float GetSFXVolume()
        {
            return 1;
        }
        
        public float GetMasterVolume()
        {

            return 1f;
        }
    }
}