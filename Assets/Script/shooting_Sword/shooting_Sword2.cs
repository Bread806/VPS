using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting_Sword2 : MonoBehaviour
{
    float sword2_speed = 10;
    public float duration = 30, scale_big = 0;
    Vector3 sword2_scale, originalScale = new Vector3(10f,10f,10f);
    public spawn_Sword2 scriptSword2;

    void Update()
    {
        if(scriptSword2 != null && scriptSword2.newDuration)
            duration = 40;
        if(scriptSword2 != null && scriptSword2.newScale_big)
            scale_big = 0.01f;
        //Debug.Log(duration);
        sword2_scale = transform.localScale;
        transform.Translate(sword2_speed*Time.deltaTime,0,sword2_speed*Time.deltaTime);
        transform.Rotate (new Vector3 (0, 540, 0) * Time.deltaTime);
        sword2_speed+=0.1f;
        transform.localScale = new Vector3(sword2_scale.x+scale_big, sword2_scale.y+scale_big, sword2_scale.z+scale_big);
        if(sword2_speed >= duration){
            transform.localScale = originalScale;
            sword2_speed = 10;
            gameObject.SetActive(false);
        }
    }
}
