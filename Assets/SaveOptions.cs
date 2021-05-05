using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveOptions : MonoBehaviour
{
    [SerializeField] public Slider slider1;
    [SerializeField] public Slider slider2;

    public void getslidersvalue(float volume){
        Debug.Log(volume);
    }

}
