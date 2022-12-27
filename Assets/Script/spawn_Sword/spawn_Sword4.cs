using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_Sword4 : MonoBehaviour
{
    public GameObject player;
    public GameObject[] Sword4Prefab = new GameObject [3];
    public GameObject[] Sword4Prefab_big = new GameObject [3];
    public int level = 0;
    int target_level = 1;
    int during_time = 5;
    public bool damage1Change = false;
    static float sword4High = 10f;
    Coroutine sword4_0, sword4_1, sword4_2, sword4_big_0, sword4_big_1, sword4_big_2;
    WaitUntil wait_level;
    WaitForSeconds waitForDuring_time;

    IEnumerator sword4_spawn(GameObject s4_Type){
        while(true){
            float x = Random.value < 0.5f ? -1f : 1f;
            float z = Random.value < 0.5f ? -1f : 1f;
            for(int i=0;i<10;i++)
                PoolManager.Release(s4_Type, new Vector3(player.transform.position.x+Random.Range(3f, 6f)*x,player.transform.position.y + sword4High,player.transform.position.z+Random.Range(3f, 6f)*z),Quaternion.Euler(Random.Range(0f, 360f),Random.Range(0f, 360f),Random.Range(0f, 360f)));
            yield return waitForDuring_time;
        }
    }
    IEnumerator sword4_big_spawn(GameObject s4_Type){
        while(true){
            float x = Random.value < 0.5f ? -1f : 1f;
            float z = Random.value < 0.5f ? -1f : 1f;
            PoolManager.Release(s4_Type, new Vector3(player.transform.position.x+Random.Range(3f, 6f)*x,player.transform.position.y + sword4High,player.transform.position.z+Random.Range(3f, 6f)*z),Quaternion.Euler(Random.Range(0f, 360f),Random.Range(0f, 360f),Random.Range(0f, 360f))).GetComponent<shooting_Sword4>().scriptSword4 = this;
            yield return waitForDuring_time;
        }
    }
    IEnumerator level_skill(){
        yield return wait_level;                                                        //間格時間變短
        during_time = 4;
        waitForDuring_time = new WaitForSeconds(during_time);
        target_level += 1;
        yield return wait_level;                                                        //間格時間變短
        during_time = 3;
        waitForDuring_time = new WaitForSeconds(during_time);
        target_level += 1;
        yield return wait_level;                                                        //多一群炸彈
        StopCoroutine(sword4_0);
        sword4_0 = StartCoroutine(sword4_spawn(Sword4Prefab[0]));
        sword4_1 = StartCoroutine(sword4_spawn(Sword4Prefab[1]));
        target_level += 1;
        yield return wait_level;                                                        //多一顆傷害3的炸彈
        StopCoroutine(sword4_0);
        StopCoroutine(sword4_1);
        sword4_0 = StartCoroutine(sword4_spawn(Sword4Prefab[0]));
        sword4_1 = StartCoroutine(sword4_spawn(Sword4Prefab[1]));
        sword4_big_0 = StartCoroutine(sword4_big_spawn(Sword4Prefab_big[0]));
        target_level += 1;
        yield return wait_level;                                                        //多一群炸彈
        StopCoroutine(sword4_0);
        StopCoroutine(sword4_1);
        StopCoroutine(sword4_big_0);
        sword4_0 = StartCoroutine(sword4_spawn(Sword4Prefab[0]));
        sword4_1 = StartCoroutine(sword4_spawn(Sword4Prefab[1]));
        sword4_2 = StartCoroutine(sword4_spawn(Sword4Prefab[2]));
        sword4_big_0 = StartCoroutine(sword4_big_spawn(Sword4Prefab_big[0]));
        target_level += 1;
        yield return wait_level;                                                        //間格時間變短
        during_time = 2;
        waitForDuring_time = new WaitForSeconds(during_time);
        target_level += 1;
        yield return wait_level;                                                        //間格時間變短
        during_time = 1;
        waitForDuring_time = new WaitForSeconds(during_time);
        target_level += 1;
        yield return wait_level;                                                        //多一顆傷害3的炸彈
        StopCoroutine(sword4_0);
        StopCoroutine(sword4_1);
        StopCoroutine(sword4_2);
        StopCoroutine(sword4_big_0);
        sword4_0 = StartCoroutine(sword4_spawn(Sword4Prefab[0]));
        sword4_1 = StartCoroutine(sword4_spawn(Sword4Prefab[1]));
        sword4_2 = StartCoroutine(sword4_spawn(Sword4Prefab[2]));
        sword4_big_0 = StartCoroutine(sword4_big_spawn(Sword4Prefab_big[0]));
        sword4_big_1 = StartCoroutine(sword4_big_spawn(Sword4Prefab_big[1]));
        target_level += 1;
        yield return wait_level;                                                        //多一顆傷害3的炸彈，且傷害3的炸彈傷害增加至5
        StopCoroutine(sword4_0);
        StopCoroutine(sword4_1);
        StopCoroutine(sword4_2);
        StopCoroutine(sword4_big_0);
        StopCoroutine(sword4_big_1);
        sword4_0 = StartCoroutine(sword4_spawn(Sword4Prefab[0]));
        sword4_1 = StartCoroutine(sword4_spawn(Sword4Prefab[1]));
        sword4_2 = StartCoroutine(sword4_spawn(Sword4Prefab[2]));
        sword4_big_0 = StartCoroutine(sword4_big_spawn(Sword4Prefab_big[0]));
        sword4_big_1 = StartCoroutine(sword4_big_spawn(Sword4Prefab_big[1]));
        sword4_big_2 = StartCoroutine(sword4_big_spawn(Sword4Prefab_big[2]));
        damage1Change = true;
    }
    void Awake(){
        wait_level = new WaitUntil( () => level == target_level);
        waitForDuring_time = new WaitForSeconds(during_time);
    }
    void Start()
    {
        sword4_0 = StartCoroutine(sword4_spawn(Sword4Prefab[0]));
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
