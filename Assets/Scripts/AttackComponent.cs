using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackComponent : MonoBehaviour
{
    public GameObject weapon1object; 
    public GameObject weapon2object;
    public GameObject specialWeaponObject; //bomb, missile...

    IWeapon weapon1;
    IWeapon weapon2;
    IWeapon specialWeapon;

    void Start()
    {
        if(weapon1object != null) weapon1 = weapon1object.GetComponent<IWeapon>();
        if(weapon2object != null) weapon2 = weapon2object.GetComponent<IWeapon>();

        if(specialWeaponObject != null) specialWeapon = specialWeaponObject.GetComponent<IWeapon>();
    }

    public void BasicAttack()
    {
        if(weapon1 != null) weapon1.Activate();
        if(weapon2 != null) weapon2.Activate();
    } 

    public void SpecialAttack()
    {
        if (specialWeapon != null) specialWeapon.Activate();
    }

}
