using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinePaper : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject flowChartObj;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FlowchartEnable()
    {
        flowChartObj.SetActive(true);
        //StartCoroutine(LoadYourAsyncScene(sceneIndex));
    }
}
