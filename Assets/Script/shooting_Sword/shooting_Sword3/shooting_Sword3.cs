using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting_Sword3 : MonoBehaviour
{
    public int damage = 1;
    public spawn_Sword3 scriptSword3;

    void Update()
    {
        if(scriptSword3 != null)
            damage = scriptSword3.damage;
        transform.Rotate (new Vector3 (0, 90, 0) * Time.deltaTime);
    }
}
