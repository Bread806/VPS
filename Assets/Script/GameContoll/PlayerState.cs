using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public GameObject weapon; 
    public GameObject backpack;
    public GameObject weaponBackground;
    public GameObject playerInterface;
    //public GameObject weapon;
    private int playerHP;
    private int playerEXP;
    // Start is called before the first frame update
    void Start()
    {
        playerHP = 100;
        playerEXP = 0;
        //weapon.GetComponent<spawn_Sword1>();
        //weapon = new GameObject[6];
        //weapon = GameObject.FindGameObjectsWithTag("Sword");
        //for (int i = 0; i < weapon.Length; i++){
        //    //print (weapon[i].level);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.K)){
            level_UP();
        }
       // print (weapon.GetComponent<spawn_Sword1>().level);
    }

    void level_UP(){
        backpack.SetActive(true);
        playerInterface.SetActive(false);
        weaponBackground.SetActive(true);
        Time.timeScale = 0f;
    }

    void on_click_level_UP(){
        //current weapon
        if (!weapon.active){
            weapon.SetActive(true);
        }
        weapon.GetComponent<spawn_Sword1>().level += 1;
        backpack.SetActive(false);
        playerInterface.SetActive(true);
        weaponBackground.SetActive(false);
    }

}
