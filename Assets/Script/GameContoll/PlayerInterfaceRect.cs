using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInterfaceRect : MonoBehaviour
{
    public HealBar healBar;
    public EXPBar expBar;
    public PlayerState player;
    void Awake(){
        healBar = GetComponent<HealBar>();
        expBar =  GetComponent<EXPBar>();
        player =  GetComponent<PlayerState>();
    }
    // Start is called before the first frame update
    void Start()
    {
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
    }

    void rect_HP(){
        healBar.set_health(player.current_HP());
    }

    void rect_EXP(){
        expBar.set_exp(player.current_EXP());
    }


}


