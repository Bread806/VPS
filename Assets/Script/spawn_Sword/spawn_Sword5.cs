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
    static float player_sword_distance = 3.5f;
    Coroutine sword5_during4, sword5_during3, sword5_during3_1, sword5_during3_2, sword5_during3_b, sword5_during3_b1, sword5_during3_b2, sword5_during3_b3, sword5_during3_b4;

    IEnumerator sword5_spawn(GameObject s5_Type,int during_time){
        while(true){
            float x = Random.value < 0.5f ? -1f : 1f;
            float z = Random.value < 0.5f ? -1f : 1f;
            float zero_or_one_x = Random.value < 0.5f ? 0f : 1f;
            float zero_or_one_z = Mathf.Approximately(zero_or_one_x, 0f) ? 1f : Random.value < 0.5f ? 0f : 1f;
            Instantiate(s5_Type, new Vector3(player.transform.position.x+Random.Range(0, 2f)*x+player_sword_distance*x*zero_or_one_x,0.5f,player.transform.position.z+Random.Range(0, 2f)*z+player_sword_distance*z*zero_or_one_z), Quaternion.Euler(0f,Random.Range(0f, 360f),0f));
            yield return new WaitForSeconds(during_time);
        }
    }
    IEnumerator level_skill(){
        yield return new WaitUntil( () => level == 1);                                  //間格時間變短
        StopCoroutine(sword5_during4);
        sword5_during3 = StartCoroutine(sword5_spawn(Sword5Prefab,3));
        yield return new WaitUntil( () => level == 2);                                  //多生成一個
        StopCoroutine(sword5_during3);
        sword5_during3 = StartCoroutine(sword5_spawn(Sword5Prefab,3));
        sword5_during3_1 = StartCoroutine(sword5_spawn(Sword5Prefab,3));
        yield return new WaitUntil( () => level == 3);                                  //多生成一個
        StopCoroutine(sword5_during3);
        StopCoroutine(sword5_during3_1);
        sword5_during3 = StartCoroutine(sword5_spawn(Sword5Prefab,3));
        sword5_during3_1 = StartCoroutine(sword5_spawn(Sword5Prefab,3));
        sword5_during3_2 = StartCoroutine(sword5_spawn(Sword5Prefab,3));
        yield return new WaitUntil( () => level == 4);                                  //其中一把變樣子變痛
        StopCoroutine(sword5_during3);
        StopCoroutine(sword5_during3);
        StopCoroutine(sword5_during3_1);
        StopCoroutine(sword5_during3_2);
        sword5_during3_b = StartCoroutine(sword5_spawn(Sword5Prefab_1,3));
        sword5_during3_1 = StartCoroutine(sword5_spawn(Sword5Prefab,3));
        sword5_during3_2 = StartCoroutine(sword5_spawn(Sword5Prefab,3));
        yield return new WaitUntil( () => level == 5);                                  //其中一把變樣子變痛
        StopCoroutine(sword5_during3);
        StopCoroutine(sword5_during3_b);
        StopCoroutine(sword5_during3_1);
        StopCoroutine(sword5_during3_2);
        sword5_during3_b = StartCoroutine(sword5_spawn(Sword5Prefab_1,3));
        sword5_during3_b1 = StartCoroutine(sword5_spawn(Sword5Prefab_1,3));
        sword5_during3_2 = StartCoroutine(sword5_spawn(Sword5Prefab,3));
        yield return new WaitUntil( () => level == 6);                                  //其中一把變樣子變痛
        StopCoroutine(sword5_during3_b);
        StopCoroutine(sword5_during3_b1);
        StopCoroutine(sword5_during3_2);
        sword5_during3_b = StartCoroutine(sword5_spawn(Sword5Prefab_1,3));
        sword5_during3_b1 = StartCoroutine(sword5_spawn(Sword5Prefab_1,3));
        sword5_during3_b2 = StartCoroutine(sword5_spawn(Sword5Prefab_1,3));
        yield return new WaitUntil( () => level == 7);                                  //間格時間變短
        StopCoroutine(sword5_during3_b);
        StopCoroutine(sword5_during3_b1);
        StopCoroutine(sword5_during3_b2);
        sword5_during3_b = StartCoroutine(sword5_spawn(Sword5Prefab_1,2));
        sword5_during3_b1 = StartCoroutine(sword5_spawn(Sword5Prefab_1,2));
        sword5_during3_b2 = StartCoroutine(sword5_spawn(Sword5Prefab_1,2));
        yield return new WaitUntil( () => level == 8);                                  //多生成兩個
        StopCoroutine(sword5_during3_b);
        StopCoroutine(sword5_during3_b1);
        StopCoroutine(sword5_during3_b2);
        sword5_during3_b = StartCoroutine(sword5_spawn(Sword5Prefab_1,2));
        sword5_during3_b1 = StartCoroutine(sword5_spawn(Sword5Prefab_1,2));
        sword5_during3_b2 = StartCoroutine(sword5_spawn(Sword5Prefab_1,2));
        sword5_during3_b3 = StartCoroutine(sword5_spawn(Sword5Prefab_1,2));
        sword5_during3_b4 = StartCoroutine(sword5_spawn(Sword5Prefab_1,2));

    }
    void Start()
    {
        sword5_during4 = StartCoroutine(sword5_spawn(Sword5Prefab,4));
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
