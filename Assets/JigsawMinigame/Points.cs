using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    public int MaxPoints;
    public int points;
    public GameObject papers;
    public GameObject button;
    // Start is called before the first frame update
    void Start()
    {
        MaxPoints = papers.transform.childCount;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (points >= MaxPoints){
            //transform.GetChild(0).gameObject.SetActive(true);
            button.SetActive(true);
        }
    }

    public void AddPoints(){
        points++;
    }
}
