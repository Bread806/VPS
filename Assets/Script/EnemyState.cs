using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour {
    public int Hp;
    public int damage;
    public int level;
    public GameObject expSpawner;
    // Start is called before the first frame update
    void Start() {
        expSpawner = GameObject.Find ("Exp Spawner");
    }

    // Update is called once per frame
    void Update() {
        if (Hp <= 0) {
            expSpawner.GetComponent<ExpSpawn>().CreatExp (this.transform.position, level);
            GameObject.Find ("Enemy Spawner").GetComponent<EnemySpawn>().EnemyDie();
            Destroy (this.gameObject);
        }
    }
    public int GetEnemyDamage() {
        return damage;
    }
    public void HurtDamage (int damage) {
        Hp -= damage;
    }
    public int GetEnemyHp() {
        return Hp;
    }
}
