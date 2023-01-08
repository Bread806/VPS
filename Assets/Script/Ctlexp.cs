using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ctlexp : MonoBehaviour
{
    public GameObject player;
    public float movementSpeed = 1;
    public int expValue;
    public int catchExp = 2;
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
        if (sqr < catchExp*catchExp)
            transform.position = Vector3.Lerp(transform.position, player.transform.position, movementSpeed);
    }
    // level 1 -> 10
    // level 2 -> 20
    // level 3 -> 30
    // level 4 -> 40
    public void ChangeExpValue (int level) {
        expValue = 10 * level;
    }
    public int GetExpValue() {
        return expValue;
    }
}
