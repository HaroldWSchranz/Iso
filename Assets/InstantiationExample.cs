using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://docs.unity3d.com/2021.3/Documentation/Manual/InstantiatingPrefabs.html
// Basics of instantiating a Prefab
public class InstantiationExample : MonoBehaviour
{
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject myPrefab;

    // This script will simply instantiate the Prefab when the game starts.
    void Start()
    {
        // Instantiate at position (0, 0, 0) and zero rotation.
        Instantiate(myPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }
}
