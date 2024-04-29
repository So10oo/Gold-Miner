using UnityEngine;

public static class ScreenSize
{
    public static float width => 2 * Camera.main.orthographicSize * Screen.width / Screen.height;
}

