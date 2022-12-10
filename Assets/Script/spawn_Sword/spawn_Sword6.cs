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
    Coroutine sword6_during3, sword6_during2, sword6_during1, sword6_during05, sword6_during0;

    IEnumerator sword6_spawn(float during_time, float spawn_time){
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
                yield return new WaitForSeconds(spawn_time);
            }   
            yield return new WaitForSeconds(during_time);
        }
    }
    IEnumerator level_skill(){
        yield return new WaitUntil( () => level == 5);
        StopCoroutine(sword6_during3);
        sword6_during2 = StartCoroutine(sword6_spawn(2f,0.2f));
        yield return new WaitUntil( () => level == 6);
        StopCoroutine(sword6_during2);
        sword6_during1 = StartCoroutine(sword6_spawn(1f,0.2f));
        yield return new WaitUntil( () => level == 7);
        StopCoroutine(sword6_during1);
        sword6_during05 = StartCoroutine(sword6_spawn(0.5f,0.2f));
        yield return new WaitUntil( () => level == 8);
        StopCoroutine(sword6_during05);
        sword6_during0 = StartCoroutine(sword6_spawn(0f,0.2f));
        /*yield return new WaitUntil( () => playspeed.level == 8);
        StopCoroutine(sword6_during0);
        sword6_during = StartCoroutine(sword6_spawn(0f,0.1f));
        for(int i=0;i<5;i++){
            var shooting_S6 = s6_Type[i].GetComponent<shooting_Sword6>();
            s6_Type[i].AddComponent<shooting_Sword6_fast>();
            DestroyImmediate(shooting_S6, true);
        }*/
    }
    void Start()
    {
        for(int i=0;i<5;i++){
            var shooting_S6 = s6_Type[i].GetComponent<shooting_Sword6>();
            var shooting_S6_f = s6_Type[i].GetComponent<shooting_Sword6_fast>();
            s6_Type[i].AddComponent<shooting_Sword6>();
            DestroyImmediate(shooting_S6_f, true);
            DestroyImmediate(shooting_S6, true);
        }
        sword6_during3 = StartCoroutine(sword6_spawn(3f,0.2f));
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
