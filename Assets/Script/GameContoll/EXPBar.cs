using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EXPBar : MonoBehaviour
{
    public Slider slider;

    public void init(int maxEXP){
        slider = this.GetComponent<Slider>();
        slider.maxValue = maxEXP;
        slider.value = 0;
        
        
    }

    public void set_zero_exp(){
        slider.value = 0;
    }

    public void set_exp(int exp){
        slider.value = exp;
    }

    public void set_max_exp(int maxExp){
        // exp counting is : maxExp = maxEXP+100
        slider.maxValue = maxExp;
    }
}
