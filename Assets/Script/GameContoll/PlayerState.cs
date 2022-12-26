using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    //public GameObject weapon; 
    private GameObject GS;
    private GameObject backpack;
    private GameObject weaponBackground;
    private GameObject playerInterface;
    private int playerHP;
    private int playerEXP;
    // Start is called before the first frame update
    void Start()
    {
        playerHP = 100;
        playerEXP = 0;
        GS = GameObject.Find("GameControll");
        backpack = GameObject.Find("Backpack");
        playerInterface = GameObject.Find("PlayInterface");
        weaponBackground = GameObject.Find("WeaponBackground");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.K)){
            GS.GetComponent<GameContoll>().LV_UP();
        }
    }

    

}
