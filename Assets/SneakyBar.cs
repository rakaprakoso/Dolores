using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SneakyBar : MonoBehaviour
{

    public Slider slider;
    public int sceneIndex;

    public void setMaxBar(int max) {
        slider.maxValue = max;
        slider.value = 0;
    
    }

    public void setBar(float Noise) {
        slider.value = Noise;
    }

    public void gameover(float noise){
        if(slider.value >= slider.maxValue){
            Debug.Log("You're dead");
            StartCoroutine(LoadYourAsyncScene(sceneIndex));
        }

    }

    public void LoadSceneNext()
    {
        StartCoroutine(LoadYourAsyncScene(sceneIndex));
    }

    public IEnumerator LoadYourAsyncScene(int index)
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneIndex);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

}
