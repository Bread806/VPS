using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting_Sword4 : MonoBehaviour
{
    WaitForSeconds WaitForS;
    IEnumerator Destroy_Sword4(){
        yield return WaitForS;
        gameObject.SetActive(false);
    }
    void Awake() {
        WaitForS = new WaitForSeconds(8);
    }
    void OnEnable()
    {
        StartCoroutine(Destroy_Sword4());
    }

}
