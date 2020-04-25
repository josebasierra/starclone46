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
        weapon1.Activate();
        weapon2.Activate();
    } 

    public void SpecialAttack()
    {

    }

    public void enemyAttack(Vector3 playerPosition) {
        weapon1.enemyAttack(playerPosition);
    }
}
