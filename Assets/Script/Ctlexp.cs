using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ctlexp : MonoBehaviour
{
    public GameObject player;
    public float movementSpeed = 1;
    void Start()
    {
        player = GameObject.Find("player");
    }

    void Update()
    {
        Controlexp();
    }
    void Controlexp()
    {
        float sqr = (transform.position - player.transform.position).sqrMagnitude;
        if (sqr < 5*5)
            transform.position = Vector3.Lerp(transform.position, player.transform.position, movementSpeed);
    }
}
