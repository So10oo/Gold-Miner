using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.Events;

public class ProgressGame : MonoBehaviour
{
    [SerializeField] UnityEvent OnStartGame;
    [SerializeField] UnityEvent OnEndGame;

    public void StartGame()
    {
        OnStartGame?.Invoke();
        isPaused = false;
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

    public void InversionPauseGame() => isPaused = !isPaused; 

    public void EndGame()
    {
        OnEndGame?.Invoke();
    }
}
