using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting_Sword2_2 : MonoBehaviour
{
    float sword2_speed = 10;
    float duration = 110;
    Vector3 sword2_scale;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        sword2_scale = transform.localScale;
        transform.Translate(sword2_speed*Time.deltaTime,0,sword2_speed*Time.deltaTime);
        transform.Rotate (new Vector3 (0, 540, 0) * Time.deltaTime);
        sword2_speed+=0.1f;
        transform.localScale = new Vector3(sword2_scale.x+0.01f,  sword2_scale.y+0.01f, sword2_scale.z+0.01f);
        Debug.Log(duration);
        if(sword2_speed >= duration)
            Destroy (this.gameObject,1);
    }
}
