using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

    private Inventory inventory;
    private PlayerController player;
    public GameObject itemButton;
    public GameObject effect;
    public GameObject flowChartObj;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) {
            //player.InspectBlink(false);
            //Debug.Log("Masuk");
        }
        
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player")) {
            // spawn the sun button at the first available inventory slot ! 
            player.InspectBlink(true);
            if (Input.GetKeyDown(KeyCode.Q)){
                Debug.Log("Kepencet");
                flowChartObj.SetActive(true);
                for (int i = 0; i < inventory.items.Length; i++)
                {
                    if (inventory.items[i] == 0) { // check whether the slot is EMPTY
                        Instantiate(effect, transform.position, Quaternion.identity);
                        inventory.items[i] = 1; // makes sure that the slot is now considered FULL
                        Instantiate(itemButton, inventory.slots[i].transform, false); // spawn the button so that the player can interact with it
                        Destroy(gameObject);
                        break;
                    }
                }
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
