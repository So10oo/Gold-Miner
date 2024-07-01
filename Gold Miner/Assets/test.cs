using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour
{
    [SerializeField] Image image;

    [SerializeField] Image image1;

    private void Awake()
    {
        var texture = image.sprite.texture;

        var texture2 = new Texture2D(texture.width, texture.height);
        Vector2Int size = new Vector2Int(15, 15);

        var s = size.x * size.y;
        for (int i = 0; i < texture.width; i++)
            for (int j = 0; j < texture.height; j++)
            {
                float r = 0;
                float g = 0;
                float b = 0;
                for (int k = i - size.x; k < i + size.x; k++)
                    for (int l = j - size.y; l < j + size.y; l++) 
                    {
                        if (k >= 0 && k < texture.width && l >= 0 && l < texture.height) 
                        {
                            var c = texture.GetPixel(l, k);
                            r += c.r;
                            g += c.g;
                            b += c.b;
                        }
                    }
                r /= s; g/=s; b/=s;
                texture2.SetPixel(i,j,new Color(r,g,b));
            }

       for (int i = 0;i < texture.width;i++)
            for (int j = 0; j < texture.height; j++)
            {
                texture.SetPixel(i, j, texture2.GetPixel(i, j));
            }
    }
}
