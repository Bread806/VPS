using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_Sword5 : MonoBehaviour
{
    public GameObject player;
    public GameObject Sword5Prefab;
    public GameObject Sword5Prefab_1;
    int level = 0;
    int damage = 3;//暫定
    int damage2 = 5;//暫定
    int target_level = 1;
    int during_time = 4;
    static float player_sword_distance = 3.5f;
    Coroutine sword5_0, sword5_1, sword5_2, sword5_big_0, sword5_big_1, sword5_big_2, sword5_big_3, sword5_big_4;
    WaitUntil wait_level;
    WaitForSeconds waitForDuring_time;

    IEnumerator sword5_spawn(GameObject s5_Type){
        while(true){
            float x = Random.value < 0.5f ? -1f : 1f;
            float z = Random.value < 0.5f ? -1f : 1f;
            float zero_or_one_x = Random.value < 0.5f ? 0f : 1f;
            float zero_or_one_z = Mathf.Approximately(zero_or_one_x, 0f) ? 1f : Random.value < 0.5f ? 0f : 1f;
            PoolManager.Release(s5_Type, new Vector3(player.transform.position.x+Random.Range(0, 2f)*x+player_sword_distance*x*zero_or_one_x,0.5f,player.transform.position.z+Random.Range(0, 2f)*z+player_sword_distance*z*zero_or_one_z), Quaternion.Euler(0f,Random.Range(0f, 360f),0f));
            yield return waitForDuring_time;
        }
    }
    IEnumerator level_skill(){
        yield return wait_level;                                  //間格時間變短
        during_time = 3;
        waitForDuring_time = new WaitForSeconds(during_time);
        target_level += 1;
        yield return wait_level;                                  //多生成一個
        StopCoroutine(sword5_0);
        sword5_0 = StartCoroutine(sword5_spawn(Sword5Prefab));
        sword5_1 = StartCoroutine(sword5_spawn(Sword5Prefab));
        target_level += 1;
        yield return wait_level;                                  //多生成一個
        StopCoroutine(sword5_0);
        StopCoroutine(sword5_1);
        sword5_0 = StartCoroutine(sword5_spawn(Sword5Prefab));
        sword5_1 = StartCoroutine(sword5_spawn(Sword5Prefab));
        sword5_2 = StartCoroutine(sword5_spawn(Sword5Prefab));
        target_level += 1;
        yield return wait_level;                                  //其中一把變樣子變痛
        StopCoroutine(sword5_0);
        StopCoroutine(sword5_1);
        StopCoroutine(sword5_2);
        sword5_big_0 = StartCoroutine(sword5_spawn(Sword5Prefab_1));
        sword5_0 = StartCoroutine(sword5_spawn(Sword5Prefab));
        sword5_1 = StartCoroutine(sword5_spawn(Sword5Prefab));
        target_level += 1;
        yield return wait_level;                                  //其中一把變樣子變痛
        StopCoroutine(sword5_big_0);
        StopCoroutine(sword5_0);
        StopCoroutine(sword5_1);
        sword5_big_0 = StartCoroutine(sword5_spawn(Sword5Prefab_1));
        sword5_big_1 = StartCoroutine(sword5_spawn(Sword5Prefab_1));
        sword5_0 = StartCoroutine(sword5_spawn(Sword5Prefab));
        target_level += 1;
        yield return wait_level;                                  //其中一把變樣子變痛
        StopCoroutine(sword5_big_0);
        StopCoroutine(sword5_big_1);
        StopCoroutine(sword5_0);
        sword5_big_0 = StartCoroutine(sword5_spawn(Sword5Prefab_1));
        sword5_big_1 = StartCoroutine(sword5_spawn(Sword5Prefab_1));
        sword5_big_2 = StartCoroutine(sword5_spawn(Sword5Prefab_1));
        target_level += 1;
        yield return wait_level;                                  //間格時間變短
        during_time = 2;
        waitForDuring_time = new WaitForSeconds(during_time);
        target_level += 1;
        yield return wait_level;                                  //多生成兩個
        StopCoroutine(sword5_big_0);
        StopCoroutine(sword5_big_1);
        StopCoroutine(sword5_big_2);
        sword5_big_0 = StartCoroutine(sword5_spawn(Sword5Prefab_1));
        sword5_big_1 = StartCoroutine(sword5_spawn(Sword5Prefab_1));
        sword5_big_2 = StartCoroutine(sword5_spawn(Sword5Prefab_1));
        sword5_big_3 = StartCoroutine(sword5_spawn(Sword5Prefab_1));
        sword5_big_4 = StartCoroutine(sword5_spawn(Sword5Prefab_1));

    }
    void Awake(){
        wait_level = new WaitUntil( () => level == target_level);
        waitForDuring_time = new WaitForSeconds(during_time);
    }
    void Start()
    {
        sword5_0 = StartCoroutine(sword5_spawn(Sword5Prefab));
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
