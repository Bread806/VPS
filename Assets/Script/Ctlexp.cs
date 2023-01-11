using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ctlexp : MonoBehaviour
{
    public GameObject player;
    public float movementSpeed = 1;
    public int expValue;
    private int playerCatchExp;
    void Start()
    {
        player = GameObject.Find("player");
        playerCatchExp = player.GetComponent<PlayerControl>().catchExp;
    }

    void Update()
    {
        Controlexp();
    }
    void Controlexp()
    {
        float sqr = (transform.position - player.transform.position).sqrMagnitude;
        if (sqr < playerCatchExp * playerCatchExp)
            transform.position = Vector3.Lerp(transform.position, player.transform.position, movementSpeed);
    }
    public int GetExpValue() {
        return expValue;
    }
}
