using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_Sword2 : MonoBehaviour
{
    public GameObject player;
    public GameObject Sword2Prefab;
    int level = 0;
    int damage = 1;//暫定
    int during_time = 5;
    static float player_sword_distance = 3f;
    Coroutine start_sword2_0,start_sword2_1,start_sword2_2;

    IEnumerator sword2_spawn(int during_time){
        //yield return new WaitForSeconds(start_time);
        while(true){
            float x = Random.value < 0.5f ? -1f : 1f;
            float z = Random.value < 0.5f ? -1f : 1f;
            Instantiate(Sword2Prefab, new Vector3(player.transform.position.x+player_sword_distance*x,0.5f,player.transform.position.z+player_sword_distance*z), Quaternion.Euler(0f,Random.Range(0f, 360f),0f));
            yield return new WaitForSeconds(during_time);
        }
    }
    IEnumerator level_skill(){
        yield return new WaitUntil( () => level == 1);
        damage += 1;
        yield return new WaitUntil( () => level == 2);
        damage += 1;
        yield return new WaitUntil( () => level == 3);
        damage += 1;
        yield return new WaitUntil( () => level == 4);
        damage += 1;
        yield return new WaitUntil( () => level == 5);                                  //持續時間增加
        var shooting_S2 = Sword2Prefab.GetComponent<shooting_Sword2>();
        Sword2Prefab.AddComponent<shooting_Sword2_1>();
        DestroyImmediate(shooting_S2, true);
        yield return new WaitUntil( () => level == 6);                                  //間格時間縮短
        during_time = 4;
        StopCoroutine(start_sword2_0);
        start_sword2_0 = StartCoroutine(sword2_spawn(during_time));
        yield return new WaitUntil( () => level == 7);                                  //多一把飛鏢
        StopCoroutine(start_sword2_0);
        start_sword2_0 = StartCoroutine(sword2_spawn(during_time));
        start_sword2_1 = StartCoroutine(sword2_spawn(during_time));
        yield return new WaitUntil( () => level == 8);                                  //多一把飛鏢
        StopCoroutine(start_sword2_0);
        StopCoroutine(start_sword2_1);
        StartCoroutine(sword2_spawn(during_time));
        StartCoroutine(sword2_spawn(during_time));
        StartCoroutine(sword2_spawn(during_time));
        yield return new WaitUntil( () => level == 9);                                  //越外圍飛鏢越大
        var shooting_S2_1 = Sword2Prefab.GetComponent<shooting_Sword2_1>();
        Sword2Prefab.AddComponent<shooting_Sword2_2>();
        DestroyImmediate(shooting_S2_1, true);
    }
    void Start()
    {
        /*var shooting_S2 = Sword2Prefab.GetComponent<shooting_Sword2>();
        var shooting_S2_1 = Sword2Prefab.GetComponent<shooting_Sword2_1>();
        var shooting_S2_2 = Sword2Prefab.GetComponent<shooting_Sword2_2>();
        DestroyImmediate(shooting_S2, true);
        Sword2Prefab.AddComponent<shooting_Sword2>();
        DestroyImmediate(shooting_S2_1, true);
        DestroyImmediate(shooting_S2_2, true);
        start_sword2_0 = StartCoroutine(sword2_spawn(during_time));
        StartCoroutine(level_skill());*/
    }
    void Update()
    {
        if(Input.GetKeyDown("space") && level<9){
            level+=1;
            //Debug.Log(level);
        }
    }
}
