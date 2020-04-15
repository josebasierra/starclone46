using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenAimComponent : MonoBehaviour
{
    public GameObject scope1Prefab;
    public GameObject scope2Prefab;

    public float scopeDistance = 20;


    private Transform scope1;
    private Transform scope2;


    void Start()
    {
        scope1 = Instantiate(scope1Prefab, this.gameObject.transform).transform;
        scope2 = Instantiate(scope2Prefab, this.gameObject.transform).transform;
    }


    void Update()
    {
        Vector3 mousePos = Input.mousePosition;

        mousePos.z = scopeDistance;
        scope2.position = Camera.main.ScreenToWorldPoint(mousePos);


        Vector3 dir = this.transform.position - scope2.position;
        scope1.position = scope2.position + (dir.normalized * dir.magnitude* 0.4f);

    }

    public Vector3 GetAimPosition()
    {
        return scope2.position;
    }


}
