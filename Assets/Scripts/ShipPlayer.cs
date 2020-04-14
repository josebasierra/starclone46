using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipPlayer : MonoBehaviour
{
    ShipMovement moveComponent;
    VisualAim aimComponent;


    void Start()
    {
        moveComponent = this.GetComponent<ShipMovement>();
        aimComponent = this.GetComponent<VisualAim>();
    }


    void Update()
    {
        Vector2 dir = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector3 objective = aimComponent.GetAimPosition();

        if(moveComponent != null) moveComponent.Execute(dir, objective, false);
    }


    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hello");
    }
}
