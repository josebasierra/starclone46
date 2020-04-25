using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
	public float cooldown = 0.5f;
	public GameObject prefabBullet;
	public float shotSpeed = 20f;
    public Transform releasePoint;
	
    float timeWithoutActivating = 0f;

    // Update is called once per frame
    void Update()
    {
		timeWithoutActivating += Time.deltaTime;
    }

    public void enemyAttack(Vector3 playerPosition) {
        if (timeWithoutActivating < cooldown) return;

        GameObject bullet = Instantiate(prefabBullet);
        bullet.transform.position = releasePoint.position;

        Vector3 shotDirection = (playerPosition - releasePoint.position).normalized;
        bullet.GetComponent<Rigidbody>().velocity = shotDirection * shotSpeed; 
        Destroy(bullet, 10);

        timeWithoutActivating = 0f;
    }
}
