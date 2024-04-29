using UnityEngine;


public class Ground : MonoBehaviour
{
    BoxCollider2D groundCollider;

    void Start()
    {
        groundCollider = GetComponent<BoxCollider2D>();
        var size = groundCollider.size;
        size.x = ScreenSize.width;
        groundCollider.size = size;
    }
}
