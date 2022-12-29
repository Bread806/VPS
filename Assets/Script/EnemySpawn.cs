using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

    public GameObject player;
    public GameObject[] enemyList;
    // 怪物總數量
    public int enemyTotal;
    // 遊戲當前怪物數量
    public int currentEnemyNumber;
    // 遊戲難度
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
    private float gamingTime;
    // 每level的怪物強度比例表
    // row為難度level, column為怪物level, 值為比例, ex: [4,2]:難度level4中level2怪的比例
    private int[,] spawnProbability;
    private int[] spawnList;

                        


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
        gamingTime = 0.0f;
        spawnProbability = new int[11,4]{ {10, 0, 0, 0}, 
                                          { 9, 1, 0, 0}, {8, 2, 0, 0},
                                          { 7, 3, 0, 0}, {5, 4, 1, 0},
                                          { 4, 5, 1, 0}, {3, 5, 2, 0},
                                          { 2, 5, 2, 1}, {1, 4, 3, 2},
                                          { 0, 4, 4, 2}, {0, 3, 4, 3}
                                        };
        spawnList = new int[10]{0,0,0,0,0,0,0,0,0,0};
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyUp(KeyCode.Z)){
            LevelUp();
        }
        gamingTime += Time.deltaTime;
        //print (gamingTime);
        if (level < 10 && gamingTime >= timeToNextLevel * (level+1)) {
            print (gamingTime);
            LevelUp();
        }
        StartCoroutine (Spawn());
    }
    public void EnemyDie() {
        currentEnemyNumber--;
    }
    private IEnumerator Spawn() {
        yield return new WaitForSeconds (waitToSpawn);
        while (currentEnemyNumber < enemyTotal) {
            RandomEnemyPosition();
            Instantiate (enemyList[RandomEnemyStrength()], enemyPosition, Quaternion.identity);
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
    private void LevelUp() {
        level++;
        ChangeSpawnList (level);
        enemyTotal += 5;
        Debug.LogFormat ("[{0}]", string.Join(", ", spawnList));
    }
    // 改變怪物強度比例
    private void ChangeSpawnList (int level) {
        int index = 0;
        for (int enemyLevel = 0; enemyLevel < 4; enemyLevel++) {
            int number =  spawnProbability[level,enemyLevel];
            while (number > 0) {
                spawnList[index] = enemyLevel;
                number--;
                index++;
            }
        }
    }
    private int RandomEnemyStrength() {
        return spawnList[Random.Range (0, 9)];
    }
    
    
}
