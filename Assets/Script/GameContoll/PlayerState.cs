using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerState : MonoBehaviour
{
    //public GameObject weapon; 
    private GameObject GS;
    private GameObject backpack;
    private GameObject weaponBackground;
    public bool isLevelUP;
    public int playerMaxHP = 100, currentHP = 0;
    public int playerEXP = 0, currentEXP = 0, maxEXP = 100;
    public int kill=0;
    // Start is called before the first frame update

    void Awake(){}
    void Start()
    {
        GS = GameObject.Find("GameControll");
        backpack = GameObject.Find("Backpack");
        weaponBackground = GameObject.Find("WeaponBackground");

        currentHP = playerMaxHP;
        isLevelUP = false;
    }

    // Update is called once per frame
    void Update()
    {
        //isLevelUP = false;
        // if (Input.GetKeyUp(KeyCode.K)){
        //     get_EXP(50);
            
        // }

        // if (Input.GetKeyUp(KeyCode.T)){
        //     take_damage(10);
        // }

        if (currentEXP >= maxEXP){
            exp_set_empty(); 
            GS.GetComponent<GameContoll>().LV_UP();
            level_up_state_update();
            exp_increase(100);
            
            
        }

        if (currentHP <= 0){
            GS.GetComponent<GameContoll>().end_game();
        }
    }

    public void take_damage(int damage){
        currentHP -= damage;
    }

    public void get_EXP(int expNumber){
        currentEXP += expNumber;
    }

    public void exp_increase(int increaseNumber){
        maxEXP += increaseNumber;
    }

    public void exp_set_empty(){
        currentEXP = 0;
    }

    public int current_HP(){
        return currentHP;
    }

    public int current_EXP(){
        return currentEXP;
    }

    public int player_max_HP(){
        return playerMaxHP;
    }

    public int max_exp(){
        return maxEXP;
    }

    public void level_up_state_update(){
        isLevelUP = !isLevelUP;
    }
    
    public void add_kill(){
        this.kill++;
    }

    public int get_current_kill(){
        return this.kill;
    }
    
    

}
