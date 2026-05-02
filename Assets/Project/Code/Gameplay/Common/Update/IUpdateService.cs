namespace Code.Gameplay.Common.Update
{
    public interface IUpdateService
    {
        GameBehaviorCollection<IGameUpdateable> Update { get; }
        GameBehaviorCollection<IGameFixedUpdateable> FixedUpdate { get; }
        GameBehaviorCollection<IGameLateUpdateable> LateUpdate { get; }
        GameBehaviorCollection<IPausable> Pausable { get; }

        void UpdateAll(float deltaTime);
        void FixedUpdateAll(float fixedDeltaTime);
        void LateUpdateAll(float deltaTime);

        void PauseAll();
        void ResumeAll();
    }
}
