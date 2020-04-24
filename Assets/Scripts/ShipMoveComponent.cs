using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMoveComponent : MonoBehaviour
{

    public float speed = 5f;
    public float lateralSpeed = 5f;
    public float boostMultiplier = 1.2f;
    public Vector2 positionLimits = new Vector2(10, 10);

    Rigidbody rigidbody;
    Transform rail;
    Vector3[] path;
    int target; // id to next position of the path to reach


    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        // init path
        Transform pathTransform = GameObject.Find("Path").transform;
        int N = pathTransform.childCount;

        path = new Vector3[N];
        for (int i = 0; i < N; i++)
        {
            path[i] = pathTransform.GetChild(i).position;
        }
        target = 0;

        // init rail
        rail = new GameObject().transform;
        rail.name = "Rail";
        rail.position = transform.position;
        rail.LookAt(path[target]);

        transform.parent = rail;
    }


    void Update()
    {
        if (target >= path.Length) return;

        rail.position += rail.forward * speed * Time.deltaTime;

        if (Vector3.Distance(rail.position, path[target]) < 2f)
        {
            target++;
            if (target < path.Length)  //rotate rail to look at the next node
            {
                //Quaternion rotation = Quaternion.FromToRotation(transform.forward, path[target] - transform.position);
                //Quaternion.RotateTowards(transform.rotation, rotation, ??)
                rail.LookAt(path[target]);
            }
        }
    }


    public void SideMove(Vector2 moveDirection)
    {
        ApplyPositionLimits(ref moveDirection);

        // moveDirection is relative to the screen, but velocity is world vector
        Vector3 worldDirection = rail.TransformDirection(moveDirection);

        rigidbody.velocity = (Vector3)worldDirection*lateralSpeed;
    }


    public void Accelerate(Vector2 moveDirection)
    {

    }


    public void LookAt(Vector3 position)
    {
        transform.LookAt(position);
    }


    public void Dodge()
    {
        //Coroutine during X seconds ??
    }


    // check positions limits and correct moveDirection to slow down ship when outside them
    private void ApplyPositionLimits(ref Vector2 moveDirection)
    {
        float x = transform.localPosition.x;
        float y = transform.localPosition.y;

        float k = 0.4f;

        if (x >= positionLimits.x && moveDirection.x > 0)
        {
            moveDirection.x *= 1 - (x - positionLimits.x) / (k * positionLimits.x);
        }
        else if (x <= -positionLimits.x && moveDirection.x < 0)
        {
            moveDirection.x *= 1 - (x - -positionLimits.x) / (k * -positionLimits.x);
        }

        if (y >= positionLimits.y && moveDirection.y > 0)
        {
            moveDirection.y *= 1 - (y - positionLimits.y) / (k * positionLimits.y);
        }
        else if (y <= -positionLimits.y && moveDirection.y < 0)
        {
            moveDirection.y *= 1 - (y - -positionLimits.y) / (k * -positionLimits.y);
        }
    }



}
