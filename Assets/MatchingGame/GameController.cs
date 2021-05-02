using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    GameObject token;
    List<int> faceindexes = new List<int> {0,1,2,3,4,5,0,1,2,3,4,5,0,1,2,3,4,5,0,1,2,3,4,5};
    public static System.Random rnd = new System.Random();
    public int shufflenum = 0;
    [SerializeField] private int points = 0;
    int[] visibleFaces = {-1,-2};
 private void Start() {
     int originalLength = faceindexes.Count;
    float yPosition = 10.49f;
    float xPosition = -17.19f;
    for (int i = 0; i <24; i++){
        shufflenum = rnd.Next(0,(faceindexes.Count));
        var temp = Instantiate(token, new Vector3(
            xPosition,yPosition,0),
            Quaternion.identity);
            temp.GetComponent<PlayerClick>().Faceindex = faceindexes[shufflenum];
            faceindexes.Remove(faceindexes[shufflenum]);
            temp.name = "Token "+i.ToString();
        xPosition = xPosition + 7.03f;
        switch(i){
            case 5:
            xPosition = -17.19f;
            yPosition = yPosition - 7.09f;
            break;
            case 11:
            xPosition = -17.19f;
            yPosition = yPosition - 7.09f;
            break;
            case 17:
            xPosition = -17.19f;
            yPosition = yPosition - 7.09f;
            break;
        }
    }
}
public bool TwoCardsUp(){
    bool cardsup = false;
    if(visibleFaces[0]>=0 && visibleFaces[1] >=0){
        cardsup = true;
    }
    return cardsup;
}

public void AddvisibleFaces (int index){
    if (visibleFaces[0] == -1){
        visibleFaces[0] = index;
    }
    else if (visibleFaces[1] == -2){
        visibleFaces[1] = index;
    }
}

public void RemovevisibleFaces (int index){
    if (visibleFaces[0] == index){
        visibleFaces[0] = -1;
    }
    else if (visibleFaces[1] == index){
        visibleFaces[1] = -2;
    }
}

public bool CheckMatch(){
    bool success = false;
    if (visibleFaces[0] == visibleFaces[1]){
        visibleFaces[0] = -1;
        visibleFaces[1] = -2;
        success = true;
        points++;
    }
    if (points==2)
    {
        Debug.Log("SUCCESS");
        StartCoroutine(LoadYourAsyncScene(5));
    }
    return success;
}

 private void Awake() {
    token = GameObject.Find("Token");
}
IEnumerator LoadYourAsyncScene(int index)
    {

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(index);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
