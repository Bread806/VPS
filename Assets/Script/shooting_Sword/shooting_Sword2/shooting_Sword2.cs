using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting_Sword2 : MonoBehaviour
{
    float sword2_speed = 10;
    float duration = 100;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(sword2_speed*Time.deltaTime,0,sword2_speed*Time.deltaTime);
        transform.Rotate (new Vector3 (0, 540, 0) * Time.deltaTime);
        sword2_speed+=0.1f;
        Debug.Log(duration);
        if(sword2_speed >= duration)
            DestroyImmediate(this.gameObject,true);
    }
}
