using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting_Sword4 : MonoBehaviour
{
    public int damage = 1;//暫定
    public int damage1 = 3;//暫定
    public spawn_Sword4 scriptSword4;
    WaitForSeconds WaitForS;
    
    IEnumerator Destroy_Sword4(){
        yield return WaitForS;
        gameObject.SetActive(false);
    }
    void Awake() {
        WaitForS = new WaitForSeconds(3);
    }
    void OnEnable()
    {
        StartCoroutine(Destroy_Sword4());
    }
    void Update(){
        if(scriptSword4 != null && scriptSword4.damage1Change)
            damage1 = 5;
    }

}
