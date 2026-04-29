using UnityEngine;

namespace Code.Infrastructure.Sounds
{
    public class SoundBuilder
    {
        private readonly SoundManager _soundManager;
        private Vector3 _position = Vector3.zero;
        private Transform _parent;
        private bool _randomPitch;

        public SoundBuilder(SoundManager soundManager)
        {
            _soundManager = soundManager;
        }

        public SoundBuilder WithPosition(Vector3 position)
        {
            _position = position;
            return this;
        }

        public SoundBuilder WithRandomPitch()
        {
            _randomPitch = true;
            return this;
        }

        public SoundBuilder WithParent(Transform parent)
        {
            _parent = parent;
            return this;
        }

        public void Play(SoundData soundData)
        {
            if (soundData == null)
            {
                Debug.LogError("SoundData is null");
                return;
            }

            if (!_soundManager.CanPlaySound(soundData))
                return;

            SoundEmitter soundEmitter = _soundManager.Get();
            soundEmitter.Initialize(soundData);
            soundEmitter.transform.position = _position;
            soundEmitter.transform.SetParent(_parent != null ? _parent : _soundManager.transform, true);

            if (_randomPitch)
                soundEmitter.WithRandomPitch();

            if (soundData.FrequentSound)
                soundEmitter.Node = _soundManager.FrequentSoundEmitters.AddLast(soundEmitter);

            soundEmitter.Play();
        }
    }
}

