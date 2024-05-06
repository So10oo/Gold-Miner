using UnityEngine;


public class MenuPage : Page
{
    [SerializeField] Window _settingsWindow;

    public override void Enter()
    {
        _settingsWindow.Close();
        base.Enter();
    }
}

