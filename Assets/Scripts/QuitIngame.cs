using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitIngame : MonoBehaviour
{
    public PlayerController PlayerController;

    public void Unpaused(bool active){
        PlayerController = FindObjectOfType<PlayerController>();
        PlayerController.IsPaused = active;
        Time.timeScale=1;
    }

}
