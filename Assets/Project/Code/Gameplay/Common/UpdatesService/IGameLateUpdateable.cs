namespace Code.Gameplay.Common.UpdatesService
{
    public interface IGameLateUpdateable
    {
        void GameLateUpdate(float deltaTime);
    }
}
