using UnityEngine;
using UnityEngine.Events;


public class GamePage : Page
{
    [SerializeField] Window _pauseWindow;

    [SerializeField] Window _gameOverWindow;
     

    public override void Enter()
    {
        _pauseWindow.Close();
        _gameOverWindow.Close();
        base.Enter();
    }

}

