using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Turret turretPrefab;

    [SerializeField] bool isPlaceable;
    public bool IsPlaceable { get { return isPlaceable; } }

    void OnMouseDown()
    {
        if (isPlaceable)
        {
            bool isPlaced = turretPrefab.CreateTurret(turretPrefab, transform.position);
            isPlaceable = !isPlaced;
        }
    }
}
