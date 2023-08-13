using UnityEngine;
using System.Collections;

public class MousePosition : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 mousePos = Input.mousePosition;
            {
                Debug.Log("(X,Y) = (" + mousePos.x + "," + mousePos.y + ")");
            }
        }
    }
}
