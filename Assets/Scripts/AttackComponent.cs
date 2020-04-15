using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackComponent : MonoBehaviour
{
    public Weapon weapon1;
    public Weapon weapon2;

    public Weapon specialWeapon; //bomb, missile...


    public void BasicAttack()
    {
        weapon1.Activate();
        weapon2.Activate();
    } 

    public void SpecialAttack()
    {

    }
}
