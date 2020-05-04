using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rotationSpeed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vectorRotation = new Vector3(1,1,1);
        transform.Rotate(vectorRotation * rotationSpeed * Time.deltaTime);
    }
}
