using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting_Sword1 : MonoBehaviour
{
    [SerializeField] float sword1_speed = 15;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.Translate(sword1_speed*Time.deltaTime,0,0);
        transform.Translate(0,sword1_speed*Time.deltaTime,0);
        if(this.transform.position.x <= 30)
            Destroy (this.gameObject,1);
    }
}
