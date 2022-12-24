using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PlayerControl : MonoBehaviour
{
    public float movementSpeed = 3;
    private int exp;
    Animator anim;
    Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        exp = 0;
    }

    void Update()
    {
        ControllPlayer();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("exptest"))
        {
            exp += 1;
            Debug.Log(exp);
            other.gameObject.SetActive(false);
        }    
    }
    void ControllPlayer()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);
        }


        transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);

    }
}
