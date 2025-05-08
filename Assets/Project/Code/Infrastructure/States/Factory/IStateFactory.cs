using Project.Code.Infrastructure.States.StateInfrastructure;

namespace Project.Code.Infrastructure.States.Factory
{
    public interface IStateFactory
    {
        T GetState<T>() where T : class, IExitableState;
    }
}