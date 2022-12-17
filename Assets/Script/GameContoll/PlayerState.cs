using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public GameObject[] weapon; 
    private int playerHP;
    private int playerEXP;
    // Start is called before the first frame update
    void Start()
    {
        playerHP = 100;
        playerEXP = 0;
        weapon = new GameObject[6];
        weapon = GameObject.FindGameObjectsWithTag("Sword");
        for (int i = 0; i < weapon.Length; i++){
            //print (weapon[i].level);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void level_UP(){
        //

    }

}
