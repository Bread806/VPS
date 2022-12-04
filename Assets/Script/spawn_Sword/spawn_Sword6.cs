using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_Sword6 : MonoBehaviour
{
    public GameObject player;
    public GameObject[] s6_Type = new GameObject [5];
    int level = 0;
    int damage = 3;//暫定
    static float player_sword_distance = 3.5f;
    float u_or_d = 1f;
    float sword6_count;
    float sword6_rotate = 270f;
    float direction = 1;
    Coroutine sword6_during3, sword6_during2, sword6_during1, sword6_during08, sword6_during05;

    IEnumerator sword6_spawn(float during_time){
        while(true){
            if(180f<player.transform.eulerAngles.y && player.transform.eulerAngles.y<360f){
                direction = -1;
                sword6_rotate = 90f;
            }
            if(0f<player.transform.eulerAngles.y && player.transform.eulerAngles.y<180f){
                direction = 1;
                sword6_rotate = 270f;
            }
            sword6_count = (level+1) > 5 ? 5 : level+1;
            for(int i=0;i<sword6_count;i++){
                Instantiate(s6_Type[i], new Vector3(player.transform.position.x+player_sword_distance*direction,0.5f,player.transform.position.z+0.6f*u_or_d),Quaternion.Euler(0f,sword6_rotate,0f));
                u_or_d *= -1;
                yield return new WaitForSeconds(0.2f);
            }   
            yield return new WaitForSeconds(during_time);
        }
    }
    IEnumerator level_skill(){
        yield return new WaitUntil( () => level == 5);
        StopCoroutine(sword6_during3);
        sword6_during2 = StartCoroutine(sword6_spawn(2f));
        yield return new WaitUntil( () => level == 6);
        StopCoroutine(sword6_during2);
        sword6_during1 = StartCoroutine(sword6_spawn(1f));
        yield return new WaitUntil( () => level == 7);
        StopCoroutine(sword6_during1);
        sword6_during08 = StartCoroutine(sword6_spawn(0.5f));
        yield return new WaitUntil( () => level == 8);
        StopCoroutine(sword6_during08);
        sword6_during05 = StartCoroutine(sword6_spawn(0f));
    }
    void Start()
    {
        sword6_during3 = StartCoroutine(sword6_spawn(3f));
        StartCoroutine(level_skill());
    }

    void Update()
    {
        if(Input.GetKeyDown("space") && level<8){
            level+=1;
            Debug.Log(level);
        }
    }
}
