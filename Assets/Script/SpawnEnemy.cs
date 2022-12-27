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
    // 生怪冷卻時間
    private float waitToSpawn;
                        


    // Start is called before the first frame update
    void Start() {
        enemyTotal = 10;
        currentEnemyNumber = 0;
        level = 0;
        timeToNextLevel = 30;
        incrementEnemy = 5;
        relativePlayerMinX = 10;
        relativePlayerMaxX = 20;
        relativePlayerMinZ = 20;
        relativePlayerMaxZ = 30;
        waitToSpawn = 1.0f;
    }

    // Update is called once per frame
    void Update() {
        StartCoroutine (Spawn());
        
    }
    private IEnumerator Spawn() {
        yield return new WaitForSeconds (waitToSpawn);
        while (currentEnemyNumber < enemyTotal) {
            RandomEnemyPosition();
            Instantiate (enemyList, enemyPosition, Quaternion.identity);
            currentEnemyNumber++;
        }
    }
    private void RandomEnemyPosition() {
        int directionX = (int)Mathf.Sign (Random.Range (-1.0f, 1.0f));
        int directionZ = (int)Mathf.Sign (Random.Range (-1.0f, 1.0f));
        enemyPosition = new Vector3 (player.transform.position.x + (Random.Range (relativePlayerMinX, relativePlayerMaxX) * directionX),
                                     player.transform.position.y,
                                     player.transform.position.z + (Random.Range (relativePlayerMinZ, relativePlayerMaxZ) * directionZ));    
    }
    public void EnemyDie() {
        currentEnemyNumber--;
    }
}
