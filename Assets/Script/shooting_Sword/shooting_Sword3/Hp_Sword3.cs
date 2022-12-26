using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hp_Sword3 : MonoBehaviour
{
    public int damage = 1;
    public spawn_Sword3 scriptSword3;

    void Update()
    {
        if(scriptSword3 != null)
            damage = scriptSword3.damage;
    }
}
