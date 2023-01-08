using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting_Sword1_all : MonoBehaviour
{
    [SerializeField] float sword1_speed = 15;
    float sum = 0f, sum1 = 0f;
    bool bSum = true,bSum1 = false;
    void Update()
    {
        if(sum < 10f && bSum){
            transform.Translate(0,sword1_speed*Time.deltaTime,0);
            sum += sword1_speed*Time.deltaTime;
        }
        if(sum >= 10f){
            bSum = false;
            bSum1 = true;
            sum = 0f;
            sum1 = 0f;
        }
        if(sum1 < 10f && bSum1){
            transform.Translate(0,-sword1_speed*Time.deltaTime,0);
            sum1 += sword1_speed*Time.deltaTime;
        }
        if(sum1 > 10f){
            bSum = true;
            bSum1 = false;
            sum = 0f;
            sum1 = 0f;
        }
    }
}
