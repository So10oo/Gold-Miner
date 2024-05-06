public interface IStateMachine<T> where T : IState
{
    public void Initialize(T State);

    public void ChangeState(T newState);
}



