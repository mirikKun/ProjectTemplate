using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Sounds.Behaviours
{
    public class SoundSource : MonoBehaviour
    {
        [SerializeField] private Transform _parent;
        private ISoundsSystem _soundsSystem;

        [Inject]
        private void Construct(ISoundsSystem soundsSystem)
        {
            _soundsSystem = soundsSystem;
        }

        public void PlaySound(SoundData soundData)
        {
            _soundsSystem.Play(soundData);
        }

        public void StopSound(SoundData soundData)
        {
            _soundsSystem.StopSound(soundData);
        }

        public void PlaySoundAtPlace(SoundData soundData)
        {
            _soundsSystem.CreateSoundBuilder()
                .WithPosition(transform.position)
                .WithParent(_parent)
                .Play(soundData);
        }

        public void PlaySoundAtPlace(SoundData soundData, Vector3 position, Transform parent)
        {
            _soundsSystem.CreateSoundBuilder()
                .WithPosition(position)
                .WithParent(parent)
                .Play(soundData);
        }
    }
}
