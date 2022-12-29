using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpSpawn : MonoBehaviour {
    public GameObject exp;
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }
    public void CreatExp (Vector3 position, int level) {
        Instantiate (exp, position, Quaternion.identity);
        exp.GetComponent<Ctlexp>().ChangeExpValue (level);
    }
}
