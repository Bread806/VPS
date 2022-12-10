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
    int target_level = 1;
    static float player_sword_distance = 3f;

    Coroutine start_sword2_0,start_sword2_1,start_sword2_2;
    WaitForSeconds waitForDuring_time;
    WaitUntil wait_level;

    IEnumerator sword2_spawn(){
        //yield return new WaitForSeconds(start_time);
        while(true){
            float x = Random.value < 0.5f ? -1f : 1f;
            float z = Random.value < 0.5f ? -1f : 1f;
            Instantiate(Sword2Prefab, new Vector3(player.transform.position.x+player_sword_distance*x,0.5f,player.transform.position.z+player_sword_distance*z), Quaternion.Euler(0f,Random.Range(0f, 360f),0f));
            yield return waitForDuring_time;
        }
    }
    IEnumerator level_skill(){
        yield return wait_level;
        damage += 1;
        target_level += 1;
        yield return wait_level;
        damage += 1;
        target_level += 1;
        yield return wait_level;
        damage += 1;
        target_level += 1;
        yield return wait_level;
        damage += 1;
        target_level += 1;
        yield return wait_level;                                                        //持續時間增加
        Sword2Prefab.GetComponent<shooting_Sword2>().duration = 110;
        target_level += 1;
        yield return wait_level;                                                        //間格時間縮短
        during_time = 4;
        waitForDuring_time = new WaitForSeconds(during_time);
        target_level += 1;
        yield return wait_level;                                                        //多一把飛鏢
        StopCoroutine(start_sword2_0);
        start_sword2_0 = StartCoroutine(sword2_spawn());
        start_sword2_1 = StartCoroutine(sword2_spawn());
        target_level += 1;
        yield return wait_level;                                                        //多一把飛鏢
        StopCoroutine(start_sword2_0);
        StopCoroutine(start_sword2_1);
        StartCoroutine(sword2_spawn());
        StartCoroutine(sword2_spawn());
        StartCoroutine(sword2_spawn());
        target_level += 1;
        yield return wait_level;                                                        //越外圍飛鏢越大
        Sword2Prefab.GetComponent<shooting_Sword2>().scale_big = 0.01f;
    }
    void Awake() {
        Sword2Prefab.GetComponent<shooting_Sword2>().duration = 100;
        Sword2Prefab.GetComponent<shooting_Sword2>().scale_big = 0f;

        waitForDuring_time = new WaitForSeconds(during_time);
        wait_level = new WaitUntil( () => level == target_level);
    }
    void Start() {
        start_sword2_0 = StartCoroutine(sword2_spawn());
        StartCoroutine(level_skill());
    }

    void Update()
    {
        if(Input.GetKeyDown("space") && level<9){
            level+=1;
            Debug.Log(level);
        }
    }
}
