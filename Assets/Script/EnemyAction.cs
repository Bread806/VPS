using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAction : MonoBehaviour {
    // 跟隨的player
    public GameObject player;
    // 怪物移動的速度
    public float speed;
    private NavMeshAgent agent;
    private Animator animator;
    private EnemyState enemyState;
    private spawn_Sword2 spawnSword2;
    

    // Start is called before the first frame update
    void Start() {
        player = GameObject.Find ("player");
        agent = this.GetComponent<NavMeshAgent>();
        animator = this.GetComponent<Animator>();
        enemyState = this.GetComponent<EnemyState>();
        spawnSword2 = GameObject.Find ("spawn_Sword2").GetComponent<spawn_Sword2>();
        speed = 1.5f;
    }

    // Update is called once per frame
    void Update() {
        // agent跟隨player位置
        // agent.SetDestination (player.transform.position);

        // 將怪物的方向轉向玩家
        transform.LookAt(player.transform);

        // 將怪物移動到玩家的位置
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // 怪物走路動畫
        animator.SetInteger("Walk", 1);
    }
     // 被武器攻擊
    void OnTriggerEnter(Collider other) {
        if (other.tag == "Sword") {
            enemyState.HurtDamage (other.GetComponent<sword_state>().damage);
            // 觸發吸血
            if (other.name == "Shuriken3(Clone)" && enemyState.GetEnemyHp() <= 0 && spawnSword2.canSuckBlood) {
                player.GetComponent<PlayerState>().HealHp(1);
                print ("heal 1 hp");
            }
        }
    }
}
