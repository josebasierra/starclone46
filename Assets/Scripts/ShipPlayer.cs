using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipPlayer : MonoBehaviour
{
    public float speed = 2f;
    public GameObject bullet;
    Rigidbody myRb;

    // Start is called before the first frame update
    void Start()
    {
        myRb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

 
        Vector3 dir = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        myRb.velocity += Time.deltaTime * speed * dir;
           

        if (dir == Vector3.zero) myRb.velocity = Vector3.zero;

        //if input disparar:
        //Instantiate(bullet);
    
    }


    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hello");
    }
}
