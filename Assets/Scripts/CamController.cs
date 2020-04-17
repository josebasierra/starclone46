using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public float smooth = 0.01f;
    public float distanceToPlayer = 10f;

    Transform player;
    Transform playerRail;



    // Update camera position after the other objects positions has been updated
    void LateUpdate()
    {
        if (player == null) FindPlayer();

        Vector3 newPosition = playerRail.position - playerRail.forward*distanceToPlayer;
        //transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smooth);
        transform.position = Vector3.Lerp(transform.position, newPosition, smooth*Time.deltaTime);
        transform.rotation = playerRail.rotation;
    }

    void FindPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerRail = player.parent;
    }
}
