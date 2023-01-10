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
    // 距離玩家X座標最小值
    public float distancePlayerMinX;
    // 距離玩家X座標最大值
    public float distancePlayerMaxX;
    // 距離玩家Z座標最小值
    public float distancePlayerMinZ;
    // 距離玩家Z座標最大值
    public float distancePlayerMaxZ;
    public Vector3 enemyPosition;
    // 生怪冷卻時間
    private float waitToSpawn;
    private float gamingTime;
    // 每level的怪物強度比例表
    // row為難度level, column為怪物level, 值為比例, ex: [4,2]:難度level4中level2怪的比例
    private int[,] spawnProbability;
    private int[] spawnList;
    private float cameraWidth;
    private float cameraHeight;
                        


    // Start is called before the first frame update
    void Start() {
        
        enemyTotal = 10;
        currentEnemyNumber = 0;
        level = 0;
        timeToNextLevel = 30;
        incrementEnemy = 5;
        distancePlayerMinX = 0.0f;
        distancePlayerMaxX = 35.0f;
        distancePlayerMinZ = 0.0f;
        distancePlayerMaxZ = 30.0f;
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
        cameraWidth = 60.0f;
        cameraHeight = 50.0f;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyUp(KeyCode.Z)){
            LevelUp();
        }
        gamingTime += Time.deltaTime;
        if (level < 10 && gamingTime >= timeToNextLevel * (level+1)) {
            LevelUp();
        }
        StartCoroutine (Spawn());
    }
    public void EnemyDie() {
        currentEnemyNumber--;
        player.GetComponent<PlayerState>().add_kill();
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
        float enemyDistanceZ = Random.Range (distancePlayerMinZ, distancePlayerMaxZ);
        if (enemyDistanceZ <= cameraHeight / 2) {
            distancePlayerMinX = cameraWidth / 2;
        }
        else {
            distancePlayerMinX = 0.0f;    
        }
        float enemyDistanceX = Random.Range (distancePlayerMinX, distancePlayerMaxX);
        enemyPosition = new Vector3 (player.transform.position.x + (enemyDistanceX * directionX),
                                     player.transform.position.y,
                                     player.transform.position.z + (enemyDistanceZ * directionZ));    
    }
    private void LevelUp() {
        level++;
        ChangeSpawnList (level);
        enemyTotal += 5;
        // Debug.LogFormat ("[{0}]", string.Join(", ", spawnList));
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
