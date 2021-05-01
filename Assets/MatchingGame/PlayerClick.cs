using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClick : MonoBehaviour
{
    GameObject gameControl;
    SpriteRenderer SpriteRenderer;
   public Sprite[] Face;
   public Sprite Back;
   public OnMouse OnMouse;
    public int Faceindex;
    private Camera MainCamera;
    public bool matched = false;
void Awake() {
     SpriteRenderer = GetComponent<SpriteRenderer>(); 
       OnMouse = new OnMouse();
       MainCamera = Camera.main;
       gameControl = GameObject.Find("GameControll");
       }
void Start() {
 OnMouse.Click.Clicked.performed += _ => PlayerClicked();   
}
void PlayerClicked(){
    DetectObject();
    
}
private void OnEnable() {
    OnMouse.Enable();
}
private void OnDisable() {
    OnMouse.Disable();
}
private void DetectObject(){
    Ray ray = MainCamera.ScreenPointToRay(OnMouse.Click.Position.ReadValue<Vector2>());
    RaycastHit2D hit = Physics2D.GetRayIntersection(ray);
       if (hit.collider !=null){
        if (SpriteRenderer.gameObject.name == hit.collider.gameObject.name){
            if(matched == false){
                if (SpriteRenderer.sprite == Back){
                     if(gameControl.GetComponent<GameController>().TwoCardsUp() == false){
                            SpriteRenderer.sprite = Face[Faceindex];
                            gameControl.GetComponent<GameController>().AddvisibleFaces(Faceindex);
                            matched = gameControl.GetComponent<GameController>().CheckMatch();
                        }
           
                 }else{
                        SpriteRenderer.sprite = Back;
                        gameControl.GetComponent<GameController>().RemovevisibleFaces(Faceindex);
                    }
            }
        }
    }
    
}
}
