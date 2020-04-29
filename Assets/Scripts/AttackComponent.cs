using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackComponent : MonoBehaviour
{
    public Weapon weapon1; 
    public Weapon weapon2;

    public Weapon specialWeapon; //bomb, missile...

    Vector3 playerPosition;

    public void BasicAttack()
    {
        if(weapon1 != null) weapon1.Activate();
        if(weapon2 != null) weapon2.Activate();
    } 

    public void SpecialAttack()
    {

    }

}
