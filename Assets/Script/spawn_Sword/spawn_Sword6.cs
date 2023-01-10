using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class spawn_Sword6 : MonoBehaviour
{
    public GameObject player;
    public GameObject[] s6_Type = new GameObject [5];
    public int level = 0;
    public AudioClip weapon_audio;
    AudioSource audiosource;
    int target_level = 5;
    static float player_sword_distance = 1.5f;
    float u_or_d = 1f;
    float sword6_count;
    float sword6_rotate = 270f;
    float direction = 1;
    float spawn_time = 0.2f;
    public float during_time = 3f;
    public bool newSpeed = false;
    WaitForSeconds WaitForSpawn_time, WaitForDuring_time;
    WaitUntil wait_level;

    IEnumerator sword6_spawn(){
        while(true){
            if(180f<player.transform.eulerAngles.y && player.transform.eulerAngles.y<360f){
                direction = -1;
                sword6_rotate = 90f;
            }
            if(0f<player.transform.eulerAngles.y && player.transform.eulerAngles.y<180f){
                direction = 1;
                sword6_rotate = 270f;
            }
            if(level==0){
                audiosource.PlayOneShot(weapon_audio);
                PoolManager.Release(s6_Type[0], new Vector3(player.transform.position.x+player_sword_distance*direction,player.transform.position.y,player.transform.position.z),Quaternion.Euler(0f,sword6_rotate,0f)).GetComponent<shooting_Sword6>().scriptSword6 = this;
                yield return WaitForSpawn_time;
            }
            else{    
                sword6_count = (level+1) > 5 ? 5 : level+1;
                for(int i=0;i<sword6_count;i++){
                    audiosource.PlayOneShot(weapon_audio);
                    PoolManager.Release(s6_Type[i], new Vector3(player.transform.position.x+player_sword_distance*direction,player.transform.position.y,player.transform.position.z+0.6f*u_or_d),Quaternion.Euler(0f,sword6_rotate,0f)).GetComponent<shooting_Sword6>().scriptSword6 = this;
                    u_or_d *= -1;
                    yield return WaitForSpawn_time;
                }  
            } 
            yield return WaitForDuring_time;
        }
    }
    IEnumerator level_skill(){
        yield return wait_level;
        during_time = 2f;
        WaitForDuring_time = new WaitForSeconds(during_time);
        target_level += 1;
        yield return wait_level;
        during_time = 1f;
        WaitForDuring_time = new WaitForSeconds(during_time);
        target_level += 1;
        yield return wait_level;
        during_time = 0.5f;
        WaitForDuring_time = new WaitForSeconds(during_time);
        target_level += 1;
        yield return wait_level;
        during_time = 0f;
        WaitForDuring_time = new WaitForSeconds(during_time);
        yield return new WaitUntil( () => player.GetComponent<PlayerControl>().speed == 10 && level == 8);
        spawn_time = 0.1f;
        WaitForSpawn_time = new WaitForSeconds(spawn_time);
        newSpeed = true;
        
        
    }
    void Awake(){
        wait_level = new WaitUntil( () => level == target_level);
        WaitForSpawn_time = new WaitForSeconds(spawn_time);
        WaitForDuring_time = new WaitForSeconds(during_time);
    }
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        StartCoroutine(sword6_spawn());
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
