using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor_left : MonoBehaviour
{   
    [SerializeField]
    Collider bound;
    public Transform prefab;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other){
        if (other.tag == "Player"){
            copyMySelf();
        }   
    }
    void copyMySelf(){
        Vector3 bound_center = bound.bounds.center;
        Vector3 extents_length = new Vector3(0,0,bound.bounds.extents.z*2);
        Instantiate(prefab,bound_center + extents_length,transform.rotation);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
