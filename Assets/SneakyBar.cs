using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SneakyBar : MonoBehaviour
{

    public Slider slider;

    public void setMaxBar(int max) {
        slider.maxValue = max;
        slider.value = 0;
    
    }

    public void setBar(float Noise) {
        slider.value = Noise;
    }
}
