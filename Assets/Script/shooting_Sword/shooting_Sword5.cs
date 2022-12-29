using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting_Sword5 : MonoBehaviour
{
    float sword5_speed;
    float sword5_speed2;
    float sword5_rotate_speed;
    float sum_distance;
    float sw5_distance;
    float sum_distance2;
    float sw5_distance2;
    Vector3 sum_rotate;
    Vector3 sw5_rotate;
    float random_rotate;
    IEnumerator change_speed(){
        while(true){
            sw5_distance = -sword5_speed*Time.deltaTime;
            transform.Translate(0,0,sw5_distance);
            sum_distance += sw5_distance*(-1f);
            if(sum_distance >= 10f){
                sword5_speed = 0;
            }
            if(Mathf.Approximately(sword5_speed, 0f)){
                sw5_rotate = new Vector3 (0, sword5_rotate_speed, 0) * Time.deltaTime;
                transform.Rotate(sw5_rotate);
                sum_rotate += sw5_rotate;
            }
            if(sum_rotate.y >= random_rotate){
                sw5_distance2 = -sword5_speed2*Time.deltaTime;
                sword5_rotate_speed = 0;
                transform.Translate(0,0,sw5_distance2);
                sum_distance2 += sw5_distance2*(-1f);
            }
            if(sum_distance2 >= 50f)
                gameObject.SetActive(false);
            yield return null;
        }
    }

    void OnEnable()
    {
        sum_distance = 0;
        sum_distance2 = 0;
        sum_rotate = new Vector3(0,0,0);
        sword5_speed = 25;
        sword5_speed2 = 100;
        sword5_rotate_speed = 1800;
        random_rotate = Random.Range(35,360);
        StartCoroutine(change_speed());
    }

}
