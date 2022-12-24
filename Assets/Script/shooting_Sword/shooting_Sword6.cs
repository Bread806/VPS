using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting_Sword6 : MonoBehaviour
{
    public float sword6_speed = 30;
    WaitForSeconds WaitForS;
    public spawn_Sword6 scriptSword6;
    public int damage = 3;//暫定

    IEnumerator Destroy_Sword5(){
        yield return WaitForS;
        gameObject.SetActive(false);
    }

    void Awake() {
        WaitForS = new WaitForSeconds(1);
    }

    void OnEnable()
    {
        if(scriptSword6 != null && scriptSword6.newSpeed)
            sword6_speed = 60;
        StartCoroutine(Destroy_Sword5());
    }

    void Update()
    {
        transform.Translate(0,0,-sword6_speed*Time.deltaTime);           
    }
}
