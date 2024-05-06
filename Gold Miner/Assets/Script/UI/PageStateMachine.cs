using UnityEngine;

public class PageStateMachine : MonoBehaviour, IStateMachine<Page>
{
    [SerializeField] Page _firstPage;

    Page _currentState;

    public virtual void ChangeState(Page newState)
    {
        _currentState.Exit();
        _currentState = newState;
        _currentState.Enter();
    }

    public virtual void Initialize(Page State)
    {
        _currentState = State;
        _currentState.Enter();
    }

    private void Start()
    {
        Initialize(_firstPage);
    }

}

