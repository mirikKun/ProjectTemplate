namespace Code.Gameplay.Common.Update
{
    public interface IGameLateUpdateable
    {
        void GameLateUpdate(float deltaTime);
    }
}
