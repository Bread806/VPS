using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting_Sword1_slow : MonoBehaviour
{
    [SerializeField] float sword1_speed = 10;
    float sum = 0f;
    int damage = 3;//暫定
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            //other.gameObject.Hp -= damage;
        }
    }
    void Update()
    {
        transform.Translate(0,sword1_speed*Time.deltaTime,0);
        sum += sword1_speed*Time.deltaTime;
        if(sum >= 15f){
            sum = 0;
            gameObject.SetActive(false);
        }
    }
}
