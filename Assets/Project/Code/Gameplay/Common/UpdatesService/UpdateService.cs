namespace Code.Gameplay.Common.UpdatesService
{
    public class UpdateService : IUpdateService
    {
        public GameBehaviorCollection<IGameUpdateable> Update { get; } = new GameBehaviorCollection<IGameUpdateable>();
        public GameBehaviorCollection<IGameFixedUpdateable> FixedUpdate { get; } = new GameBehaviorCollection<IGameFixedUpdateable>();
        public GameBehaviorCollection<IGameLateUpdateable> LateUpdate { get; } = new GameBehaviorCollection<IGameLateUpdateable>();
        public GameBehaviorCollection<IPausable> Pausable { get; } = new GameBehaviorCollection<IPausable>();

        public void UpdateAll(float deltaTime)
        {
            Update.ExecuteAll((u, dt) => u.GameUpdate(dt), deltaTime);
        }

        public void FixedUpdateAll(float fixedDeltaTime)
        {
            FixedUpdate.ExecuteAll((u, dt) => u.GameFixedUpdate(dt), fixedDeltaTime);
        }

        public void LateUpdateAll(float deltaTime)
        {
            LateUpdate.ExecuteAll((u, dt) => u.GameLateUpdate(dt), deltaTime);
        }

        public void PauseAll()
        {
            Pausable.ExecuteAll(p => p.Pause());
        }

        public void ResumeAll()
        {
            Pausable.ExecuteAll(p => p.Resume());
        }
    }
}
