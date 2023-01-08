using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword_state : MonoBehaviour
{
    public int damage;
    public int playerAtk = 0;
    int atk = 0;
    //public int level;
    public spawn_Sword2 scriptSword2;
    public spawn_Sword3 scriptSword3;
    public spawn_Sword4 scriptSword4;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(scriptSword2 != null)
            damage = scriptSword2.damage;
        if(scriptSword3 != null)
            damage = scriptSword3.damage;
        if(scriptSword4 != null && scriptSword4.damage1Change)
            damage = 5;
        if(playerAtk != atk){
            atk = playerAtk;
            damage += atk;
        }
    }
}
