using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class spawn_Sword2 : MonoBehaviour
{
    public GameObject player;
    public GameObject Sword2Prefab;
    public AudioClip weapon_audio;
    AudioSource audiosource;
    public int level = 0;
    public int damage = 10;//暫定
    int during_time = 5;
    public int target_level = 1;
    static float player_sword_distance = 1f;
    public bool newDuration = false, newScale_big = false;

    Coroutine start_sword2_0,start_sword2_1,start_sword2_2;
    WaitForSeconds waitForDuring_time;
    WaitUntil wait_level;

    IEnumerator sword2_spawn(){
        //yield return new WaitForSeconds(start_time);
        while(true){
            float x = Random.value < 0.5f ? -1f : 1f;
            float z = Random.value < 0.5f ? -1f : 1f;
            audiosource.PlayOneShot(weapon_audio);
            GameObject temp = PoolManager.Release(Sword2Prefab, new Vector3(player.transform.position.x+player_sword_distance*x,player.transform.position.y,player.transform.position.z+player_sword_distance*z), Quaternion.Euler(0f,Random.Range(0f, 360f),0f)) as GameObject;
            temp.GetComponent<shooting_Sword2>().scriptSword2 = this;
            temp.GetComponent<sword_state>().scriptSword2 = this;
            yield return waitForDuring_time;
        }
    }
    IEnumerator level_skill(){
        yield return wait_level;
        damage += 10;
        target_level += 1;
        yield return wait_level;
        damage += 10;
        target_level += 1;
        yield return wait_level;
        damage += 10;
        target_level += 1;
        yield return wait_level;
        damage += 10;
        target_level += 1;
        yield return wait_level;                                                        //持續時間增加
        newDuration = true;
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
        newScale_big = true;
    }
    void Awake() {
        damage = 10;
        waitForDuring_time = new WaitForSeconds(during_time);
        wait_level = new WaitUntil( () => level == target_level);
    }
    void Start() {
        audiosource = GetComponent<AudioSource>();
        start_sword2_0 = StartCoroutine(sword2_spawn());
        StartCoroutine(level_skill());
    }

    void Update()
    {
        // if(Input.GetKeyDown("space") && level<9){
        //     level+=1;
        //     Debug.Log(level);
        // }
    }

}
