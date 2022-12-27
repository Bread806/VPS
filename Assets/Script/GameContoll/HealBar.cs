using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealBar : MonoBehaviour
{
    public Slider slider;
    public void set_max_health(int health){
        //init health
        slider = this.GetComponent<Slider>();
        slider.maxValue = health;
        slider.value = health;
    }

    public void set_health(int health){
        slider.value = health;
    }
}
