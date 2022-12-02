using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting_Sword4 : MonoBehaviour
{
    IEnumerator Destroy_Sword4(){
        yield return new WaitForSeconds(5);
        Destroy (this.gameObject,1);
    }
    void Start()
    {
        StartCoroutine(Destroy_Sword4());
    }

    // Update is called once per frame
    void Update()
    {
            
    }
}
