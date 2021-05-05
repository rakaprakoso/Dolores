using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Pickup : MonoBehaviour {

    private Inventory inventory;
    private PlayerController player;
    public GameObject itemButton;
    public GameObject effect;
    public GameObject flowChartObj;
    public Flowchart flowchart;
    public bool check = false;
    public bool hit = false;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

    }

    private void Update(){
        if(check){
            if (flowchart.GetBooleanVariable("DialogEnd")){
                Debug.Log("HAPUS OBJECT");
                Destroy(this.gameObject);
                //flowChartObj.SetActive(false);
            }    
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) {
            if (hit){
                flowChartObj.SetActive(true);
                Debug.Log("Kepencet");
                for (int i = 0; i < inventory.items.Length; i++)
                {
                    if (inventory.items[i] == 0) { // check whether the slot is EMPTY
                        Instantiate(effect, transform.position, Quaternion.identity);
                        inventory.items[i] = 1; // makes sure that the slot is now considered FULL
                        Instantiate(itemButton, inventory.slots[i].transform, false); // spawn the button so that the player can interact with it
                        check = true;
                        break;
                    }
                }
            }
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
                flowChartObj.SetActive(true);
                Debug.Log("Kepencet");
                for (int i = 0; i < inventory.items.Length; i++)
                {
                    if (inventory.items[i] == 0) { // check whether the slot is EMPTY
                        Instantiate(effect, transform.position, Quaternion.identity);
                        inventory.items[i] = 1; // makes sure that the slot is now considered FULL
                        Instantiate(itemButton, inventory.slots[i].transform, false); // spawn the button so that the player can interact with it
                        check = true;
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
