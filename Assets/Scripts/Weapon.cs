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

        GameObject bullet = Instantiate(prefabBullet);
        bullet.tag = transform.parent.gameObject.tag;
        bullet.transform.position = releasePoint.position;

        Vector3 shotDirection = (endPoint.position - releasePoint.position).normalized;
        bullet.GetComponent<Rigidbody>().velocity = shotDirection * shotSpeed;

        Destroy(bullet, 10);    //destroy bullet after N seconds

        timeWithoutActivating = 0f;
    }

}
