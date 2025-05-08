namespace Project.Code.Infrastructure.States.StateInfrastructure
{
    public interface IPayloadState<TPayload> : IExitableState
    {
        void Enter(TPayload payload);
    }
}