using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor_right : MonoBehaviour
{   
    [SerializeField]
    Collider bound;
    public Transform prefab;
    int count_scene = 0; 
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other){
        if ((other.tag == "Player" )& (count_scene == 0)){
            count_scene+=1;
            copyMySelf();
        }   
    }
    void copyMySelf(){
        Vector3 now_position = this.transform.position;
        Vector3 extents_length = new Vector3(bound.bounds.extents.x*2,0,0);
        Instantiate(prefab,now_position + extents_length,transform.rotation);
    }
    void Start(){}
    // Update is called once per frame
    void Update(){}
}
