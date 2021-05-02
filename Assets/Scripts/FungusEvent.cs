using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FungusEvent : MonoBehaviour
{
    private PlayerController player;
    public GameObject flowChartObj;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        flowChartObj.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player")) {
            // spawn the sun button at the first available inventory slot ! 
            player.InspectBlink(true);
            if (Input.GetKeyDown(KeyCode.Q)){
                Debug.Log("Kepencet");
                flowChartObj.SetActive(true);
            }
        }
        
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) {
            // spawn the sun button at the first available inventory slot ! 
            player.InspectBlink(false);
        }
        
    }
}
