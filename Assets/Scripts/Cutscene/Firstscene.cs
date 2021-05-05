using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Firstscene : MonoBehaviour
{
    private Image rend;
    public Sprite catSprite, monsterSprite;
    public Sprite[] spriteList;
    private int index = 0;
    public Animator transitionAnim;
    public Animator transitionTextAnim;
    public string sceneName;
    public Scene sceneNext;

    // Start is called before the first frame update
    private void Start()
    {
        rend = GetComponent<Image>();
        //catSprite = Resources.Load<Sprite>("/Assets/Image/Cutscene/First/1");
        //monsterSprite = Resources.Load<Sprite>("Monster");
        rend.sprite = spriteList[index];
    }

    // Update is called once per frame
    void Update()
    {
        Keyboard kb = InputSystem.GetDevice<Keyboard>();
        if(kb.qKey.wasPressedThisFrame){
            if (index==7)
            {
                StartCoroutine(LoadScene());
            }else{
                if (index==0){
                    index=1;
                }
                StartCoroutine(LoadNextImage());
                //rend.sprite = spriteList[index++];
            }
            /*if (rend.sprite == catSprite){
                rend.sprite = monsterSprite;
            }else{
                rend.sprite = catSprite;
            }*/
        }
        
    }

    IEnumerator LoadScene(){
        transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneName);
    }
    IEnumerator LoadNextImage(){
        transitionAnim.SetTrigger("End");
        transitionTextAnim.SetTrigger("Loop");
        yield return new WaitForSeconds(1.5f);
        rend.sprite = spriteList[index++];
        
    }

}
