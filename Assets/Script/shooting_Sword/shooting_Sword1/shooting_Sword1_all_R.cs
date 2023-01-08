using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting_Sword1_all_R : MonoBehaviour
{
    void Update()
    {
        transform.Rotate (new Vector3 (0, 180, 0) * Time.deltaTime);
    }
}
