using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_enemy : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject camera;
    public int spawn_time;
    public int spawn_quantity;

    public void spawnNew()
    {
        StartCoroutine(spawn(spawn_time,spawn_quantity));
    }
    IEnumerator spawn(int spawn_time, int spawn_quantity)
    {
        float cameraX = camera.transform.position.x;
        float cameraZ = camera.transform.position.z+10f;
        yield return new WaitForSeconds(spawn_time);
        for(int i=0;i<spawn_quantity;i++){  //上方生成敵人
            GameObject nb = Instantiate(enemyPrefab) as GameObject;
            nb.transform.position = new Vector3(Random.Range(cameraX+(-15f), cameraX+15f), 0.5f, Random.Range(cameraZ+10f, cameraZ+15f));
        }
        for(int i=0;i<spawn_quantity;i++){  //下方生成敵人
            GameObject nb = Instantiate(enemyPrefab) as GameObject;
            nb.transform.position = new Vector3(Random.Range(cameraX+(-15f),cameraX+15f), 0.5f, Random.Range(cameraZ+(-15f), cameraZ+(-10f)));
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawn(0,20));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
