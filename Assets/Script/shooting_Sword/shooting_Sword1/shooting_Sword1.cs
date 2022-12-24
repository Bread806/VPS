using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting_Sword1 : MonoBehaviour
{
    [SerializeField] float sword1_speed = 15;
    float sum = 0f;
    int damage = 5;//暫定
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            //other.gameObject.GetComponent<xxx>().Hp -= damage;
            //Debug.Log(other.gameObject);
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
