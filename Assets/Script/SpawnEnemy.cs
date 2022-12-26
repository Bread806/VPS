using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour {

    public GameObject player;
    public GameObject enemyList;
    // 怪物總數量
    public int enemyTotal;
    // 遊戲當前怪物數量
    public int currentEnemyNumber;
    // 難度等級
    public int level;
    // 升級level時間
    public int timeToNextLevel;
    // 增加怪物數量
    public int incrementEnemy;
    // 玩家X座標最小距離
    public int relativePlayerMinX;
    // 玩家X座標最大距離
    public int relativePlayerMaxX;
    // 玩家Z座標最小距離
    public int relativePlayerMinZ;
    // 玩家Z座標最大距離
    public int relativePlayerMaxZ;
    public Vector3 enemyPosition;
                        


    // Start is called before the first frame update
    void Start() {
        enemyTotal = 10;
        currentEnemyNumber = 0;
        level = 0;
        timeToNextLevel = 30;
        incrementEnemy = 5;
        relativePlayerMinX = 20;
        relativePlayerMaxX = 40;
        relativePlayerMinZ = 20;
        relativePlayerMaxZ = 40;
    }

    // Update is called once per frame
    void Update() {
        StartCoroutine (Spawn());
        
    }
    private IEnumerator Spawn() {
        yield return new WaitForSeconds (1);
        while (currentEnemyNumber < enemyTotal) {
            RandomEnemyPosition();
            Instantiate (enemyList, enemyPosition, Quaternion.identity);
            currentEnemyNumber++;
            Debug.Log ("目前怪物數量: " + currentEnemyNumber);
        }
        
    }
    private void RandomEnemyPosition() {
        int directionX = (int)Mathf.Sign (Random.Range (-1.0f, 1.0f));
        int directionZ = (int)Mathf.Sign (Random.Range (-1.0f, 1.0f));
        //Debug.LogFormat ("X: {0}, Z: {1}", directionX, directionZ);
        enemyPosition = new Vector3 (player.transform.position.x + (Random.Range (relativePlayerMinX, relativePlayerMaxX) * directionX),
                                     0.0f,
                                     player.transform.position.z + (Random.Range (relativePlayerMinZ, relativePlayerMaxZ) * directionZ));    
    }
    public void EnemyDie() {
        currentEnemyNumber--;
        Debug.Log ("目前怪物數量: " + currentEnemyNumber);
    }
}
