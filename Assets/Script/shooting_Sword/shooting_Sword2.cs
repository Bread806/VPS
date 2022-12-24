using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting_Sword2 : MonoBehaviour
{
    float sword2_speed = 10;
    public float duration = 100, scale_big = 0;
    int damage = 1;
    Vector3 sword2_scale, originalScale = new Vector3(15f,15f,15f);
    public spawn_Sword2 scriptSword2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            //other.gameObject.GetComponent<xxx>().Hp -= damage;
            //Debug.Log(other.gameObject);
        }
    }

    void OnEnable() {
        if(scriptSword2 != null && scriptSword2.newDuration)
            duration = 110;
        if(scriptSword2 != null && scriptSword2.newScale_big)
            scale_big = 0.01f;
        if(scriptSword2 != null)
            damage = scriptSword2.damage;
    }

    void Update()
    {
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
