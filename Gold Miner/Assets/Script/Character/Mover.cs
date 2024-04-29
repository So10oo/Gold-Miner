using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Mover : MonoBehaviour
{
    [SerializeField] float _speed;

    float minX;
    float maxX;


    private void Start()
    {
        var collider = GetComponent<BoxCollider2D>();
        minX = -ScreenSize.width / 2 + collider.size.x / 2;
        maxX = ScreenSize.width / 2 - collider.size.x / 2;
    }

    //private void Update()
    //{
    //    var a = Input.GetAxis("Horizontal");
    //    var b = transform.position;
    //    b.x += a * _speed * Time.deltaTime;
    //    b.x = Mathf.Clamp(b.x, minX, maxX);
    //    transform.position = b;
    //}



    private void OnMouseDrag()
    {
        var current = transform.position;
        float target = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        target = Mathf.Clamp(target, minX, maxX);
        current.x = Mathf.MoveTowards(current.x, target, _speed * Time.deltaTime);
        transform.position = current;
    }
}
