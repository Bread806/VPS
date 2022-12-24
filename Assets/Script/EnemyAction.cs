using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAction : MonoBehaviour {
    // 跟隨的player
    public GameObject player;
    private NavMeshAgent agent;
    private Animator animator;
    // Start is called before the first frame update
    void Start() {
        player = GameObject.Find ("player");
        agent = this.GetComponent<NavMeshAgent>();
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        // Vector3 direction = player.transform.position - transform.position;  
        // float angle = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg;
        // transform.rotation = Quaternion.AngleAxis (angle, Vector3.right);

        // agent跟隨player位置
        agent.SetDestination (player.transform.position);
        // 怪物走路動畫
        animator.SetInteger("Walk", 1);
    }
}
