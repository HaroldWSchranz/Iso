using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeTransparent : MonoBehaviour
{

    [SerializeField] private List<IAmInTheWay> currentlyInTheWay;
    [SerializeField] private List<IAmInTheWay> alreadyTransparent;
    [SerializeField] private Transform player;
    new private Transform camera;

    private void Awake()
    {
        currentlyInTheWay = new List<IAmInTheWay>();
        alreadyTransparent = new List<IAmInTheWay>();

        camera = this.gameObject.transform;
    }

    private void Update()
    {
        GetAllObjectsInTheWay();
        MakeObjectsSolid();
        MakeObjectsTransparent();
    }

    private void GetAllObjectsInTheWay()
    {
        currentlyInTheWay.Clear();

        float camerPlayerDistance = Vector3.Magnitude(camera.position - player.position);

        Ray ray1_Forward = new Ray(camera.position, player.position-camera.position);
        Ray ray1_Backward = new Ray(player.position, camera.position - player.position);

        var hits1_Forward = Physics.RaycastAll(ray1_Forward, camerPlayerDistance);
        var hits1_Backward = Physics.RaycastAll(ray1_Backward, camerPlayerDistance);

        foreach (var hit in hits1_Forward)
        {
            if(hit.collider.gameObject.TryGetComponent(out IAmInTheWay inTheWay))
            {
                if (!currentlyInTheWay.Contains(inTheWay))
                {
                    currentlyInTheWay.Add(inTheWay);
                }
            }
        }
        foreach (var hit in hits1_Backward)
        {
            if (hit.collider.gameObject.TryGetComponent(out IAmInTheWay inTheWay))
            {
                if (!currentlyInTheWay.Contains(inTheWay))
                {
                    currentlyInTheWay.Add(inTheWay);
                }
            }
        }
    }

    private void MakeObjectsTransparent()
    {
        for (int i = 0; i < currentlyInTheWay.Count; i++)
        {
            IAmInTheWay inTheWay = currentlyInTheWay[i];

            if (!alreadyTransparent.Contains(inTheWay))
            {
                inTheWay.ShowTransparent();
                alreadyTransparent.Add(inTheWay);
            }
        }
    }

    private void MakeObjectsSolid()
    {
        for (int i = alreadyTransparent.Count - 1; i >= 0; i--)
        {
            IAmInTheWay wasInTheWay = alreadyTransparent[i];

            if(!currentlyInTheWay.Contains(wasInTheWay))
            {
                wasInTheWay.ShowSolid();
                alreadyTransparent.Remove(wasInTheWay);
            }
        }
    }
}
