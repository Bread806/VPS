using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_Sword3 : MonoBehaviour
{
    public GameObject player;
    public GameObject Sword3Prefab;
    public GameObject Sword3Prefab_R_L;
    public GameObject Sword3Prefab_All;
    GameObject Sw3,Sw3_R_L;
    int level = 0;
    int damage = 1;//暫定
    int target_level = 1;
    Vector3 sword3_scale;
    private Vector3 offset;
    WaitUntil wait_level;

    IEnumerator level_skill(){
        sword3_scale = Sw3.transform.localScale;
        yield return wait_level;
        damage += 1;
        target_level += 1;
        yield return wait_level;
        damage += 1;
        target_level += 1;
        yield return wait_level;                                                        //範圍變大
        Sw3.transform.localScale = new Vector3(6f,  6f, 0);
        target_level += 1;
        yield return wait_level;
        damage += 1;
        target_level += 1;
        yield return wait_level;
        damage += 1;
        target_level += 1;
        yield return wait_level;                                                        //範圍變大
        Sw3.transform.localScale = new Vector3(8f,  8f, 0);
        target_level += 1;
        yield return wait_level;                                                        //多兩顆小球在旁邊轉
        Sw3_R_L = Instantiate(Sword3Prefab_R_L, this.transform);
        target_level += 1;
        yield return wait_level;                                                        //多四顆小球在旁邊轉
        DestroyImmediate(Sw3_R_L,true);
        damage += 5;
        Instantiate(Sword3Prefab_All, this.transform);
    }
    void Awake(){
        wait_level = new WaitUntil( () => level == target_level);
    }
    void Start()
    {    
        Sw3 = Instantiate(Sword3Prefab, this.transform) as GameObject;
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
