using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_Sword1 : MonoBehaviour
{
    public GameObject player;
    public GameObject Sword1Prefab_Normal;
    int level = 0;
    int damage = 5;//暫定
    static float player_sword_distance = 1f;
    public GameObject[] s1_Type = new GameObject [7];
    Vector3[] s1_Position = {new Vector3(0f,0.5f,player_sword_distance), new Vector3(player_sword_distance,0.5f,player_sword_distance), new Vector3(player_sword_distance,0.5f,0f), new Vector3(player_sword_distance,0.5f,-player_sword_distance),
                             new Vector3(0f,0.5f,-player_sword_distance), new Vector3(-player_sword_distance,0.5f,-player_sword_distance), new Vector3(-player_sword_distance,0.5f,0f), new Vector3(-player_sword_distance,0.5f,player_sword_distance)};
    Quaternion[] s1_Quaternion = {Quaternion.Euler(90f,0f,0f), Quaternion.Euler(90f,45f,0f), Quaternion.Euler(90f,90f,0f), Quaternion.Euler(90f,135f,0f), 
                                  Quaternion.Euler(90f,180f,0f), Quaternion.Euler(90f,225f,0f), Quaternion.Euler(90f,270f,0f), Quaternion.Euler(90f,315f,0f)};
    Coroutine U_R_D_L,RU_RD_LU_LD,all_direction;


    IEnumerator sword1_spawn(int type,int add,int start_time,int end_time){
        yield return new WaitForSeconds(start_time);
        while(true){
            for(int i=type;i<8;i+=add){
                if(i<level)
                    Instantiate(s1_Type[i], player.transform.position+s1_Position[i], s1_Quaternion[i]);
                else
                    Instantiate(Sword1Prefab_Normal, player.transform.position+s1_Position[i], s1_Quaternion[i]);
            }
            
            yield return new WaitForSeconds(end_time);
        }
    }
    IEnumerator spawn(){
        yield return new WaitUntil( () => level == 8);
        StopCoroutine(U_R_D_L);
        StopCoroutine(RU_RD_LU_LD);
        StopCoroutine(all_direction);
        StartCoroutine(sword1_spawn(0,2,0,3));
        StartCoroutine(sword1_spawn(1,2,1,3));
        StartCoroutine(sword1_spawn(0,1,2,3));
    }
    void Start()
    {       
        /*U_R_D_L = StartCoroutine(sword1_spawn(0,2,0,6));
        RU_RD_LU_LD = StartCoroutine(sword1_spawn(1,2,2,6));
        all_direction = StartCoroutine(sword1_spawn(0,1,4,6));
        StartCoroutine(spawn());*/
    }
    
    void Update()
    {
        if(Input.GetKeyDown("space") && level<8){
            level+=1;
        }
    }
}
