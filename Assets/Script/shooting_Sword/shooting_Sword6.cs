using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting_Sword6 : MonoBehaviour
{
    float sword6_speed = 30;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0,0,-sword6_speed*Time.deltaTime);
        if(this.transform.position.x >= 30)
            DestroyImmediate(this.gameObject,true);
    }
}
