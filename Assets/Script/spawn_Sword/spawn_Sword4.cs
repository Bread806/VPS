using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_Sword4 : MonoBehaviour
{
    public GameObject player;
    public GameObject[] Sword4Prefab = new GameObject [3];
    public GameObject[] Sword4Prefab_big = new GameObject [3];
    int level = 0;
    int damage = 1;//暫定
    int damage1 = 3;//暫定
    Coroutine sword4_during5,sword4_during4,sword4_during3,sword4_during3_1,sword4_during3_2,sword4_big_during3,sword4_big_during3_1,sword4_big_during3_2;

    IEnumerator sword4_spawn(GameObject s4_Type, int during_time){
        while(true){
            float x = Random.value < 0.5f ? -1f : 1f;
            float z = Random.value < 0.5f ? -1f : 1f;
            for(int i=0;i<10;i++)
                Instantiate(s4_Type, new Vector3(player.transform.position.x+Random.Range(3f, 6f)*x,10f,player.transform.position.z+Random.Range(3f, 6f)*z),Quaternion.Euler(Random.Range(0f, 360f),Random.Range(0f, 360f),Random.Range(0f, 360f)));            
            yield return new WaitForSeconds(during_time);
        }
    }
    IEnumerator sword4_big_spawn(GameObject s4_Type, int during_time){
        while(true){
            float x = Random.value < 0.5f ? -1f : 1f;
            float z = Random.value < 0.5f ? -1f : 1f;
            Instantiate(s4_Type, new Vector3(player.transform.position.x+Random.Range(3f, 6f)*x,10f,player.transform.position.z+Random.Range(3f, 6f)*z),Quaternion.Euler(Random.Range(0f, 360f),Random.Range(0f, 360f),Random.Range(0f, 360f)));            
            yield return new WaitForSeconds(during_time);
        }
    }
    IEnumerator level_skill(){
        yield return new WaitUntil( () => level == 1);                                  //間格時間變短
        StopCoroutine(sword4_during5);
        sword4_during4 = StartCoroutine(sword4_spawn(Sword4Prefab[0],4));
        yield return new WaitUntil( () => level == 2);                                  //間格時間變短
        StopCoroutine(sword4_during4);
        sword4_during3 = StartCoroutine(sword4_spawn(Sword4Prefab[0],3));
        yield return new WaitUntil( () => level == 3);                                  //多一群群炸彈
        StopCoroutine(sword4_during3);
        sword4_during3 = StartCoroutine(sword4_spawn(Sword4Prefab[0],3));
        sword4_during3_1 = StartCoroutine(sword4_spawn(Sword4Prefab[1],3));
        yield return new WaitUntil( () => level == 4);                                  //多一顆傷害3的炸彈
        StopCoroutine(sword4_during3);
        StopCoroutine(sword4_during3_1);
        sword4_during3 = StartCoroutine(sword4_spawn(Sword4Prefab[0],3));
        sword4_during3_1 = StartCoroutine(sword4_spawn(Sword4Prefab[1],3));
        sword4_big_during3 = StartCoroutine(sword4_big_spawn(Sword4Prefab_big[0],3));
        yield return new WaitUntil( () => level == 5);                                  //多一群群炸彈
        StopCoroutine(sword4_during3);
        StopCoroutine(sword4_during3_1);
        StopCoroutine(sword4_big_during3);
        sword4_during3 = StartCoroutine(sword4_spawn(Sword4Prefab[0],3));
        sword4_during3_1 = StartCoroutine(sword4_spawn(Sword4Prefab[1],3));
        sword4_during3_2 = StartCoroutine(sword4_spawn(Sword4Prefab[2],3));
        sword4_big_during3 = StartCoroutine(sword4_big_spawn(Sword4Prefab[0],3));
        yield return new WaitUntil( () => level == 6);                                  //間格時間變短
        StopCoroutine(sword4_during3);
        StopCoroutine(sword4_during3_1);
        StopCoroutine(sword4_during3_2);
        StopCoroutine(sword4_big_during3);
        sword4_during3 = StartCoroutine(sword4_spawn(Sword4Prefab[0],2));
        sword4_during3_1 = StartCoroutine(sword4_spawn(Sword4Prefab[1],2));
        sword4_during3_2 = StartCoroutine(sword4_spawn(Sword4Prefab[2],2));
        sword4_big_during3 = StartCoroutine(sword4_big_spawn(Sword4Prefab[0],2));
        yield return new WaitUntil( () => level == 7);                                  //間格時間變短
        StopCoroutine(sword4_during3);
        StopCoroutine(sword4_during3_1);
        StopCoroutine(sword4_during3_2);
        StopCoroutine(sword4_big_during3);
        sword4_during3 = StartCoroutine(sword4_spawn(Sword4Prefab[0],1));
        sword4_during3_1 = StartCoroutine(sword4_spawn(Sword4Prefab[1],1));
        sword4_during3_2 = StartCoroutine(sword4_spawn(Sword4Prefab[2],1));
        sword4_big_during3 = StartCoroutine(sword4_big_spawn(Sword4Prefab[0],1));
        yield return new WaitUntil( () => level == 8);                                  //多一顆傷害3的炸彈
        StopCoroutine(sword4_during3);
        StopCoroutine(sword4_during3_1);
        StopCoroutine(sword4_during3_2);
        StopCoroutine(sword4_big_during3);
        sword4_during3 = StartCoroutine(sword4_spawn(Sword4Prefab[0],1));
        sword4_during3_1 = StartCoroutine(sword4_spawn(Sword4Prefab[1],1));
        sword4_during3_2 = StartCoroutine(sword4_spawn(Sword4Prefab[2],1));
        sword4_big_during3 = StartCoroutine(sword4_big_spawn(Sword4Prefab_big[0],1));
        sword4_big_during3_1 = StartCoroutine(sword4_big_spawn(Sword4Prefab_big[1],1));
        yield return new WaitUntil( () => level == 9);                                  //多一顆傷害3的炸彈，且傷害3的炸彈傷害增加至5
        StopCoroutine(sword4_during3);
        StopCoroutine(sword4_during3_1);
        StopCoroutine(sword4_during3_2);
        StopCoroutine(sword4_big_during3);
        StopCoroutine(sword4_big_during3_1);
        sword4_during3 = StartCoroutine(sword4_spawn(Sword4Prefab[0],1));
        sword4_during3_1 = StartCoroutine(sword4_spawn(Sword4Prefab[1],1));
        sword4_during3_2 = StartCoroutine(sword4_spawn(Sword4Prefab[2],1));
        sword4_big_during3 = StartCoroutine(sword4_big_spawn(Sword4Prefab_big[0],1));
        sword4_big_during3_1 = StartCoroutine(sword4_big_spawn(Sword4Prefab_big[1],1));
        sword4_big_during3_2 = StartCoroutine(sword4_big_spawn(Sword4Prefab_big[2],1));
        damage1 += 2;
    }
    void Start()
    {
        sword4_during5 = StartCoroutine(sword4_spawn(Sword4Prefab[0],5));
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
