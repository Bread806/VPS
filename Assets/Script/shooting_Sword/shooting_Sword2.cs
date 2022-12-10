using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting_Sword2 : MonoBehaviour
{
    float sword2_speed = 10;
    public float duration;
    public float scale_big;
    Vector3 sword2_scale;

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(duration);
        sword2_scale = transform.localScale;
        transform.Translate(sword2_speed*Time.deltaTime,0,sword2_speed*Time.deltaTime);
        transform.Rotate (new Vector3 (0, 540, 0) * Time.deltaTime);
        sword2_speed+=0.1f;
        transform.localScale = new Vector3(sword2_scale.x+scale_big, sword2_scale.y+scale_big, sword2_scale.z+scale_big);
        if(sword2_speed >= duration)
            DestroyImmediate(this.gameObject,true);
    }
}
