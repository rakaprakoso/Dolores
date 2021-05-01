using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PanelImageAlpha : MonoBehaviour
{

    public Image ImageAlpha;
    // Start is called before the first frame update
    public void ChangeBgColortoBlack()
    {
        ImageAlpha.GetComponent<Image>().color = new Color32(100,100,100,255);
    }
     public void ChangeBgColortoOri()
    {
        ImageAlpha.GetComponent<Image>().color = new Color32(255,255,255 ,255);
    }
}
