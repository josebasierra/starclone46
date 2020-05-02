using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(LineRenderer))]
public class LaserWeapon : MonoBehaviour, IWeapon
{

    //[Range(0, 1)] public float laserWidth;
    public float dps;
    public float range;
    public Transform startPoint;
    public Transform endPoint;

    private LineRenderer lineRenderer;

    public void Activate()
    {
        throw new System.NotImplementedException();
    }

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.useWorldSpace = true;

        //lineRenderer.startWidth = laserWidth;
        //lineRenderer.endWidth = laserWidth;

        Vector3 laserDirection = (endPoint.position - startPoint.position).normalized;
        lineRenderer.SetPosition(0, startPoint.position);
        lineRenderer.SetPosition(1, startPoint.position+ range * laserDirection);
    }


    void Update()
    {
        Vector3 laserDirection = (endPoint.position - startPoint.position).normalized;
        RaycastHit hit;
        if (Physics.Raycast(startPoint.position, laserDirection, out hit, range))
        {
            Health health = hit.transform.GetComponent<Health>();
            if (health != null)
            {
                Debug.Log("Laser damage!");
                health.takeDamage(dps * Time.deltaTime);
            }
            lineRenderer.SetPosition(1, hit.point);
        }
        else
        {
            lineRenderer.SetPosition(1, startPoint.position + range * laserDirection);
        }
    }
}
