using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(LineRenderer))]
public class LaserWeapon : MonoBehaviour, IWeapon
{
    public float dps;
    public float range;
    public Transform startPoint;
    public Transform endPoint;

    private LineRenderer lineRenderer;
    private bool isActivated;


    public void Activate()
    {
        isActivated = true;
    }


    void Start()
    {
        isActivated = false;
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.useWorldSpace = true;

        // laser no visible
        lineRenderer.SetPosition(0, startPoint.position);
        lineRenderer.SetPosition(1, startPoint.position);
    }


    void LateUpdate()
    {
        if (isActivated)
            EmitLaser();
        else
        {
            lineRenderer.SetPosition(0, startPoint.position);
            lineRenderer.SetPosition(1, startPoint.position);
        }
        isActivated = false;

    }


    //TODO: Ignore owner of the laser, desactive beam when not calling to Activate
    void EmitLaser()
    {
        lineRenderer.SetPosition(0, startPoint.position);
        Vector3 laserDirection = (endPoint.position - startPoint.position).normalized;
        RaycastHit hit;


        if (Physics.Raycast(startPoint.position, laserDirection, out hit, range))
        {
            Health health = hit.transform.GetComponent<Health>();
            if (health != null)
            {
                Debug.Log("Laser damage!");
                health.TakeDamage(dps * Time.deltaTime);
            }
            lineRenderer.SetPosition(1, hit.point);
        }
        else
        {
            lineRenderer.SetPosition(1, startPoint.position + range * laserDirection);
        }
    }
}
