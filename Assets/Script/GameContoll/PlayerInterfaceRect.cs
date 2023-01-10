using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;


public class PlayerInterfaceRect : MonoBehaviour

{

    public TMP_Text gameTime, gameKill;
    private int m=0,s=0,ct;

    public HealBar healBar;
    public EXPBar expBar;
    public PlayerState player;
    void Awake(){
        healBar = GetComponent<HealBar>();
        expBar =  GetComponent<EXPBar>();
        player =  GetComponent<PlayerState>();
        gameTime = GetComponent<TMP_Text>();
        gameKill = GetComponent<TMP_Text>();
    }
    // Start is called before the first frame update
    void Start()
    {
        gameTime = GameObject.Find("Time").GetComponent<TMP_Text>();
        gameKill = GameObject.Find("KillNumber").GetComponent<TMP_Text>();
        healBar= GameObject.Find("HealBar").GetComponent<HealBar>();
        expBar = GameObject.Find("EXPBar").GetComponent<EXPBar>();
        player = GameObject.Find("player").GetComponent<PlayerState>();



        expBar.init(player.max_exp());expBar.set_zero_exp();
        healBar.set_max_health(player.playerMaxHP);

    }

    // Update is called once per frame
    void Update()
    {
        if (player.isLevelUP){
            expBar.set_zero_exp();
            expBar.set_max_exp(player.max_exp());
            Debug.Log (player.max_exp());
            player.level_up_state_update();
        }
        rect_HP();
        rect_EXP();
        show_current_time();
        show_current_kill();
        //show_EXP();
        //show_HP();
    }

    void rect_HP(){
        healBar.set_health(player.current_HP());
    }

    void rect_EXP(){
        expBar.set_exp(player.current_EXP());
    }

    void show_current_time(){
        ct=Convert.ToInt32(FindObjectOfType<GameContoll>().current_time());
        s = ct % 60; m = ct / 60;
        if (s < 10) {
            gameTime.text = m.ToString() + " : 0" +s.ToString();    
        }
        else {
            gameTime.text = m.ToString() + " : " +s.ToString();
        }
        
    }

    void show_current_kill(){
        gameKill.text = player.get_current_kill().ToString();
    }

}


