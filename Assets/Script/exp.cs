using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exp : MonoBehaviour {
    // 初始值
    private int expValue;
    // Start is called before the first frame update
    void Start() {
        expValue = 10;    
    }

    // Update is called once per frame
    void Update() {
        
    }
    // level 1 -> 10
    // level 2 -> 20
    // level 3 -> 30
    // level 4 -> 40
    public void ChangeExpValue (int level) {
        this.expValue = expValue * level;
    }
    public int GetExpValue() {
        return expValue;
    }
}
