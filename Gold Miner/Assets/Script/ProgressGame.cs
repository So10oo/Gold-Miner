using System;
using UnityEngine;
using UnityEngine.Events;

public class ProgressGame : MonoBehaviour
{
    [SerializeField] UnityEvent OnStartGame;
    [SerializeField] UnityEvent OnEndGame;

    public Action OnStartGameAction;
    public Action OnEndGameAction;

    public void StartGame()
    {
        OnStartGameAction?.Invoke();
        OnStartGame?.Invoke();
        isPaused = false;
        _isRun = true;
    }

    bool _isPaused;
    bool isPaused
    {
        get 
        {
            return _isPaused;
        }
        set 
        { 
            _isPaused = value;
            if (_isPaused)
                Time.timeScale = 0;
            else
                Time.timeScale = 1;
        }
    }

    bool _isRun;
    public bool isRun => _isRun;

    public void InversionPauseGame() => isPaused = !isPaused; 

    public void EndGame()
    {
        _isRun = false;
        OnEndGameAction?.Invoke();
        OnEndGame?.Invoke();
    }
}
