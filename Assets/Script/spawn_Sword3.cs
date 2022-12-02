using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_Sword3 : MonoBehaviour
{
    public GameObject player;
    //public GameObject camera;
    public GameObject Sword3Prefab;
    public GameObject Sword3Prefab_R_L;
    public GameObject Sword3Prefab_All;
    GameObject Sw3,Sw3_R_L;
    int level = 0;
    int damage = 1;//暫定
    Vector3 sword3_scale;
    private Vector3 offset;

    IEnumerator level_skill(){
        sword3_scale = Sw3.transform.localScale;
        yield return new WaitUntil( () => level == 1);
        damage += 1;
        yield return new WaitUntil( () => level == 2);
        damage += 1;
        yield return new WaitUntil( () => level == 3);                                  //範圍變大
        Sw3.transform.localScale = new Vector3(6f,  6f, 0);
        yield return new WaitUntil( () => level == 4);
        damage += 1;
        yield return new WaitUntil( () => level == 5);
        damage += 1;
        yield return new WaitUntil( () => level == 6);                                  //範圍變大
        Sw3.transform.localScale = new Vector3(8f,  8f, 0);
        yield return new WaitUntil( () => level == 7);                                  //多兩顆小球在旁邊轉
        Sw3_R_L = Instantiate(Sword3Prefab_R_L, this.transform);
        yield return new WaitUntil( () => level == 8);                                  //多四顆小球在旁邊轉
        DestroyImmediate(Sw3_R_L,true);
        damage += 5;
        Instantiate(Sword3Prefab_All, this.transform);
    }
    void Start()
    {    
        Sw3 =  Instantiate(Sword3Prefab, this.transform) as GameObject;
        offset = this.transform.position - player.transform.position;
        StartCoroutine(level_skill());
        
    }
    
    void Update()
    {
        if(Input.GetKeyDown("space") && level<8){
            level+=1;
            Debug.Log(level);
        }
        transform.position = player.transform.position + offset;
    }
}
