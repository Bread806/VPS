using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControl : MonoBehaviour
{
    public float turnSpeed = 20f;
    public float speed = 3;
    Animator m_Animator;
    Vector3 m_Movement;
    Rigidbody m_Rigidbody;
    Quaternion m_Rotation = Quaternion.identity;
    Animator anim;
    Rigidbody rb;
    private PlayerState playerState;
    
    void Start()
    {
        m_Animator = GetComponentInChildren<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
        playerState = GetComponent<PlayerState>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        m_Movement.Set(horizontal, 0f, vertical);
        m_Movement.Normalize();
        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        m_Animator.SetBool("isWalking", isWalking);
        transform.position += m_Movement * speed * (isWalking ? 1f : 0f) * Time.deltaTime;
        transform.LookAt(transform.position + m_Movement);
    }
   
    private void OnTriggerStay(Collider other) {
         // 吸取經驗值
        if (other.tag == "exptest" ) {
            playerState.get_EXP (other.GetComponent<exp>().GetExpValue());
            Destroy (other.gameObject);
        }
        // 受到攻擊
        if (other.tag == "enemy") {
            playerState.take_damage (other.GetComponent<EenemyState>().GetEnemyDamage());
        }
    }
}
