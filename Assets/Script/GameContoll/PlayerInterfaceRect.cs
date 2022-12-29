using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PlayerInterfaceRect : MonoBehaviour

{

    public TMP_Text BPHPText;

    public TMP_Text BPEXPText;

    public HealBar healBar;
    public EXPBar expBar;
    public PlayerState player;
    void Awake(){
        healBar = GetComponent<HealBar>();
        expBar =  GetComponent<EXPBar>();
        player =  GetComponent<PlayerState>();
        //BPEXPText = GetComponent<TMP_Text>();
        //BPHPText = GetComponent<TMP_Text>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //BPHPText = GameObject.Find("BHPText").GetComponent<TMP_Text>();
        //BPEXPText = GameObject.Find("BEXPText").GetComponent<TMP_Text>();
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
        //show_EXP();
        //show_HP();
    }

    void rect_HP(){
        healBar.set_health(player.current_HP());
    }

    void rect_EXP(){
        expBar.set_exp(player.current_EXP());
    }

    private void show_EXP(){
        BPEXPText.text = player.current_EXP().ToString() + " / " + player.max_exp().ToString();
    }

    private void show_HP(){
        BPHPText.text = player.current_HP().ToString();
    }


}


