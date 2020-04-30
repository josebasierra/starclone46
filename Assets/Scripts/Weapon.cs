using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float cooldown = 0.5f;
    public float shotSpeed = 20f;
    public int ammunition = -1; // -1 == infinite
    public GameObject prefabBullet;

    public Transform releasePoint;
    public Transform endPoint;

    float timeWithoutActivating = 0f;


    void Update()
    {
        timeWithoutActivating += Time.deltaTime;
    }


    public void Activate()
    {
        if (timeWithoutActivating < cooldown) return;
        timeWithoutActivating = 0f;

        Transform bulletTransform = Instantiate(prefabBullet).transform;
        bulletTransform.tag = transform.parent.gameObject.tag;

        bulletTransform.position = releasePoint.position;
        bulletTransform.LookAt(endPoint);
        bulletTransform.Rotate(new Vector3(90, 0, 0));

        Vector3 shotDirection = (endPoint.position - releasePoint.position).normalized;
        bulletTransform.GetComponent<Rigidbody>().velocity = shotDirection * shotSpeed;

        Destroy(bulletTransform.gameObject, 6);    //destroy bullet after N seconds
    }

}
