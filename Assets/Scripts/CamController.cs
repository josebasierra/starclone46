using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public float speed = 0.01f;
    public float distanceToPlayer = 10f;

    Transform player;


    // Update camera position after the other objects positions has been updated
    void LateUpdate()
    {
        if (player == null) FindPlayer();

        Vector3 newPosition = new Vector3(0f, 0f, player.position.z - distanceToPlayer);
        transform.position = newPosition;
        //transform.position = Vector3.Lerp(transform.position, newPosition, speed*Time.deltaTime);
    }

    void FindPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
}
