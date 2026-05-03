namespace Code.Gameplay.Common.UpdatesService
{
    public interface IGameFixedUpdateable
    {
        void GameFixedUpdate(float fixedDeltaTime);
    }
}
