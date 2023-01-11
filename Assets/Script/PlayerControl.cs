using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControl : MonoBehaviour
{
    public float turnSpeed = 20f;
    public float speed = 3;
    public int catchExp = 2;
    Animator m_Animator;
    Vector3 m_Movement;
    Rigidbody m_Rigidbody;
    Quaternion m_Rotation = Quaternion.identity;
    Animator anim;
    Rigidbody rb;
    private PlayerState playerState;
    private bool isHurt;
    private float cantHurtTime;
    void Start()
    {
        m_Animator = GetComponentInChildren<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
        playerState = GetComponent<PlayerState>();
        isHurt = false;
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
        if(!(Input.GetKey("space")))
            transform.LookAt(transform.position + m_Movement);
    }
    
    private void OnTriggerStay(Collider other) {
         // 吸取經驗值
        if (other.tag == "exptest" ) {
            print ("get " + other.GetComponent<Ctlexp>().GetExpValue() + " exp");
            playerState.get_EXP (other.GetComponent<Ctlexp>().GetExpValue());
            Destroy (other.gameObject);
            
        }
        // 受到攻擊
        if (other.tag == "enemy") {
            if (!isHurt) {
                isHurt = true;
                cantHurtTime = 0.5f;
                playerState.take_damage (other.GetComponent<EnemyState>().GetEnemyDamage());
            }
            cantHurtTime -= Time.deltaTime;
            if (cantHurtTime <= 0.0f) {
                isHurt = false;
            }
            
        }
    }
}
