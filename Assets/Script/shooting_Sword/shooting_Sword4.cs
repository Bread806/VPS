using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting_Sword4 : MonoBehaviour
{
    WaitForSeconds WaitForS;
    IEnumerator Destroy_Sword4(){
        yield return WaitForS;
        Destroy (this.gameObject,1);
    }
    void Awake() {
        WaitForS = new WaitForSeconds(5);
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
