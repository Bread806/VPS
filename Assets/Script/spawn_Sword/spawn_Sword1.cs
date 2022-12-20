using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_Sword1 : MonoBehaviour
{
    public GameObject player;
    public GameObject Sword1Prefab_Normal;
    public int level = 0;
    int damage = 5;//暫定
    int start_time;
    int end_time;
    static float player_sword_distance = 1f;
    public GameObject[] s1_Type = new GameObject [7];
    Vector3[] s1_Position = {new Vector3(0f,0.5f,player_sword_distance), new Vector3(player_sword_distance,0.5f,player_sword_distance), new Vector3(player_sword_distance,0.5f,0f), new Vector3(player_sword_distance,0.5f,-player_sword_distance),
                             new Vector3(0f,0.5f,-player_sword_distance), new Vector3(-player_sword_distance,0.5f,-player_sword_distance), new Vector3(-player_sword_distance,0.5f,0f), new Vector3(-player_sword_distance,0.5f,player_sword_distance)};
    Quaternion[] s1_Quaternion = {Quaternion.Euler(90f,0f,0f), Quaternion.Euler(90f,45f,0f), Quaternion.Euler(90f,90f,0f), Quaternion.Euler(90f,135f,0f), 
                                  Quaternion.Euler(90f,180f,0f), Quaternion.Euler(90f,225f,0f), Quaternion.Euler(90f,270f,0f), Quaternion.Euler(90f,315f,0f)};
    Coroutine U_R_D_L,RU_RD_LU_LD,all_direction;

    WaitForSeconds waitForStart_time0, waitForStart_time1, waitForStart_time2, waitForEnd_time0, waitForEnd_time1;


    IEnumerator sword1_spawn(int type,int add,WaitForSeconds waitForStart_time,WaitForSeconds waitForEnd_time){
        yield return waitForStart_time;
        while(true){
            for(int i=type;i<8;i+=add){
                if(i<level)
                    PoolManager.Release(s1_Type[i], player.transform.position+s1_Position[i], s1_Quaternion[i]);
                else
                    PoolManager.Release(Sword1Prefab_Normal, player.transform.position+s1_Position[i], s1_Quaternion[i]);
            }
            
            yield return waitForEnd_time;
        }
    }
    IEnumerator level_skill(){
        yield return new WaitUntil( () => level == 8);
        end_time = 3;
        waitForEnd_time0 = new WaitForSeconds(end_time);
        start_time = 0;
        waitForStart_time0 = new WaitForSeconds(start_time);
        start_time = 1;
        waitForStart_time1 = new WaitForSeconds(start_time);
        start_time = 2;
        waitForStart_time2 = new WaitForSeconds(start_time);
        StopCoroutine(U_R_D_L);
        StopCoroutine(RU_RD_LU_LD);
        StopCoroutine(all_direction);
        StartCoroutine(sword1_spawn(0,2,waitForStart_time0,waitForEnd_time0));
        StartCoroutine(sword1_spawn(1,2,waitForStart_time1,waitForEnd_time0));
        StartCoroutine(sword1_spawn(0,1,waitForStart_time2,waitForEnd_time0));
    }
    void Awake()
    {
        end_time = 6;
        waitForEnd_time0 = new WaitForSeconds(end_time);
        start_time = 0;
        waitForStart_time0 = new WaitForSeconds(start_time);
        start_time = 2;
        waitForStart_time1 = new WaitForSeconds(start_time);
        start_time = 4;
        waitForStart_time2 = new WaitForSeconds(start_time); 
    }
    void Start(){
        U_R_D_L = StartCoroutine(sword1_spawn(0,2,waitForStart_time0,waitForEnd_time0));
        RU_RD_LU_LD = StartCoroutine(sword1_spawn(1,2,waitForStart_time1,waitForEnd_time0));
        all_direction = StartCoroutine(sword1_spawn(0,1,waitForStart_time2,waitForEnd_time0));
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
