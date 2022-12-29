using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_Sword3 : MonoBehaviour
{
    public GameObject player;
    public GameObject Sword3Prefab;
    public GameObject Sword3Prefab_R_L;
    public GameObject Sword3Prefab_All;
    GameObject Sw3,Sw3_R_L,Sw3_all;
    public int level = 0;
    public int damage = 5;//暫定
    int target_level = 1;
    Vector3 sword3_scale;
    private Vector3 offset;
    WaitUntil wait_level;

    IEnumerator level_skill(){
        sword3_scale = Sw3.transform.localScale;
        yield return wait_level;
        damage += 5;
        target_level += 1;
        yield return wait_level;
        damage += 5;
        target_level += 1;
        yield return wait_level;                                                        //範圍變大
        Sw3.transform.localScale = new Vector3(6f,  6f, 0);
        target_level += 1;
        yield return wait_level;
        damage += 5;
        target_level += 1;
        yield return wait_level;
        damage += 5;
        target_level += 1;
        yield return wait_level;                                                        //範圍變大
        Sw3.transform.localScale = new Vector3(8f,  8f, 0);
        target_level += 1;
        yield return wait_level;                                                        //多兩顆小球在旁邊轉
        Sw3_R_L.SetActive(true);
        target_level += 1;
        yield return wait_level;                                                        //多四顆小球在旁邊轉
        Sw3_R_L.SetActive(false);
        damage += 25;
        Sw3_all.SetActive(true);
    }
    void Awake(){
        wait_level = new WaitUntil( () => level == target_level);
        damage = 5;
    }
    void Start()
    {    
        Sw3 = Instantiate(Sword3Prefab, player.transform.position, Quaternion.Euler(0f,0f,0f)) as GameObject;
        Sw3_R_L = Instantiate(Sword3Prefab_R_L, player.transform.position, Quaternion.Euler(0f,0f,0f));
        Sw3_all = Instantiate(Sword3Prefab_All, player.transform.position, Quaternion.Euler(0f,0f,0f));
        Sw3.GetComponent<sword_state>().scriptSword3 = this;
        Sw3_R_L.GetComponent<sword_state>().scriptSword3 = this;
        Sw3_all.GetComponent<sword_state>().scriptSword3 = this;
        Sw3_R_L.SetActive(false);
        Sw3_all.SetActive(false);
        offset = Sw3.transform.position - player.transform.position;
        StartCoroutine(level_skill());
        
    }
    
    void Update()
    {
        if(Input.GetKeyDown("space") && level<8){
            level+=1;
            Debug.Log(level);
        }
        Sw3.transform.position = player.transform.position + offset;
        Sw3_R_L.transform.position = player.transform.position + offset;
        Sw3_all.transform.position = player.transform.position + offset;
    }
}
