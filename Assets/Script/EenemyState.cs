using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EenemyState : MonoBehaviour {
    public int Hp;
    public int damage;
    public int level;
    public GameObject exp;
    // Start is called before the first frame update
    void Start() {
        exp.GetComponent<exp>().ChangeExpValue (level);
    }

    // Update is called once per frame
    void Update() {
        if (Hp <= 0) {
            Instantiate (exp, this.transform.position, Quaternion.identity);
            GameObject.Find ("Enemy Spawner").GetComponent<SpawnEnemy>().EnemyDie();
            Destroy (this.gameObject);
        }
    }
    // 被武器攻擊
    void OnTriggerStay(Collider other) {
        // 檢測敵人碰撞
        if (other.tag == "Player") {
            print ("Die");
            Hp = 0;
        }
    }
    public int GetEnemyDamage() {
        return damage;
    }
}
