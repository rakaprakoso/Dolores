using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovePiece : MonoBehaviour
{
    private DragDrop DragDrop;
    private Camera MainCamera;
    private bool isGrabbing = false;
    private bool isPlacement = false;
    private bool isMousePressed = false;
    private bool Moveobj = false;
    [SerializeField] public int points = 0;
    
   private RaycastHit2D hit;
   private Ray ray;
   void Awake() {
    DragDrop = new DragDrop();
    MainCamera = Camera.main;
  }
    void Start()
    {
        DragDrop.Drag.Click.performed +=_ => PlayerClickPiece();
        DragDrop.Drag.RightClick.performed +=_ => PlayerDropPiece();
    }

    // Update is called once per frame
    void Update()
    {
        if(Moveobj == true){            
            ObjectFollowMouse();
        }
    }
    private void OnEnable() {
    DragDrop.Enable();
}
private void OnDisable() {
    DragDrop.Disable();
}
void PlayerClickPiece(){
    ray = MainCamera.ScreenPointToRay(DragDrop.Drag.Posistion.ReadValue<Vector2>());
    hit = Physics2D.GetRayIntersection(ray);
    if (hit.collider !=null){
        if(gameObject.name == hit.collider.gameObject.name){
            if(isGrabbing){
                isGrabbing = false;
            }
            else{
                isGrabbing = true;
                DetectPiece();
            }
        }
    }
    
}
void PlayerDropPiece(){
 ray = MainCamera.ScreenPointToRay(DragDrop.Drag.Posistion.ReadValue<Vector2>());
    hit = Physics2D.GetRayIntersection(ray);
    if (hit.collider !=null){
        if(gameObject.name == hit.collider.gameObject.name){
            if (!isMousePressed){
                    isMousePressed = true;
                }
        }
    }
}
private void DetectPiece(){
     ray = MainCamera.ScreenPointToRay(DragDrop.Drag.Posistion.ReadValue<Vector2>());
        hit = Physics2D.GetRayIntersection(ray);
    if(!isPlacement){
        if(isGrabbing){
            if(hit.collider!=null){
                if(gameObject.name == hit.collider.gameObject.name){
                    Moveobj = true;
                
                }
            }
        }
    }    
}
private void ObjectFollowMouse(){
    Vector2 Mousepos = DragDrop.Drag.Posistion.ReadValue<Vector2>();
    Vector2 objPosisiton = Camera.main.ScreenToWorldPoint(Mousepos);
    transform.position = objPosisiton;
}
void OnTriggerStay2D(Collider2D other) {
     ray = MainCamera.ScreenPointToRay(DragDrop.Drag.Posistion.ReadValue<Vector2>());
     hit = Physics2D.GetRayIntersection(ray);
     if (hit.collider != null)
     {
         if ((other.gameObject.name == gameObject.name) && (isMousePressed) ){
                transform.position = other.gameObject.transform.position;
                isPlacement = true;
                isGrabbing = false;
                isMousePressed=false;
                Moveobj = false;
                GameObject.Find("PointsToWin").GetComponent<Points>().AddPoints();
            }    
        }
    
    }

}
