using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Copy_Ground : MonoBehaviour
{
    void OnTriggerEnter(Collider other){
        if (other.tag == "Player"){
            Copy();
        }
    }
    void Copy(){}


}
