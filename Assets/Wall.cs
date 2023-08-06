using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 
public class Wall : MonoBehaviour
{
    public GameObject block;
    public int width = 15;
    public int height = 10;

    void Start()
    {
        for (int y = 0; y < height; ++y)
        {
            for (int x = y; x < width; ++x)
            {
                Instantiate(block, transform.position + new Vector3(x, y+0.5f, 10), Quaternion.identity);
            }
        }
    }
}
