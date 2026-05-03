using System;

namespace Code.Gameplay.Common.TimeService
{
    public interface ITimeService
    {
        float DeltaTime { get; }
        float FixedDeltaTime { get; }
        DateTime UtcNow { get; }
        float TimeScale { get; }
        void StopTime();
        void StartTime();
        event Action<float> TimeScaleChanged;
        void SetTimeScale(float timeScale);
    }
}