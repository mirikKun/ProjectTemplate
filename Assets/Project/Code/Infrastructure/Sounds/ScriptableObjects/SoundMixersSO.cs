using UnityEngine;
using UnityEngine.Audio;

namespace Code.Infrastructure.Sounds.ScriptableObjects
{
    [CreateAssetMenu(fileName = "SoundMixersConfig", menuName = "ScriptableObjects/Sound/SoundMixersConfig")]

    public class SoundMixersSO:ScriptableObject
    {
        [field:SerializeField] public AudioMixerGroup MusicGroup { get; private set; }
        [field:SerializeField] public AudioMixerGroup SoundGroup { get; private set; }
        [field: SerializeField] public float MinimalVolume { get; private set; } = -80;
        [field: SerializeField] public float DefaultVolume { get; private set; } = 0;

        [SerializeField] private string _masterVolumeParameter = "MasterVolume";
        [SerializeField] private string _musicVolumeParameter = "MusicVolume";
        [SerializeField] private string _sfxVolumeParameter = "SoundsVolume";

        public string MasterVolumeParameter => _masterVolumeParameter;
        public string MusicVolumeParameter => _musicVolumeParameter;
        public string SfxVolumeParameter => _sfxVolumeParameter;
    }
}