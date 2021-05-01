using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory1 : MonoBehaviour
{

    private DragDrop Invent;
    private RaycastHit2D hit;
    private Ray ray;
    private Camera MainCamera;
    private bool hide = true;

     private void Awake() {
        Invent = new DragDrop();
        MainCamera = Camera.main;
    }
    // Start is called before the first frame update
    void Start()
    {
        Invent.Drag.Click.performed += _ => BringInventory();
    }
    
    public void changepos(){
        if (hide){
            transform.position = new Vector2(44.22f,transform.position.y);
            //this.RectTransform.position.x = ;
            hide = false;
        }else{
            transform.position = new Vector2(-31.7f,transform.position.y);
            //this.RectTransform.position.x = ;
            hide = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        ray = MainCamera.ScreenPointToRay(Invent.Drag.Posistion.ReadValue<Vector2>());
        hit = Physics2D.GetRayIntersection(ray);
        if (hit.collider != null){
             //Debug.Log(hit.collider.gameObject.name);
        }
    }

    private void OnEnable() {
        Invent.Enable();
    }
    private void OnDisable() {
        Invent.Disable();
    }

   void BringInventory(){
    ray = MainCamera.ScreenPointToRay(Invent.Drag.Posistion.ReadValue<Vector2>());
    hit = Physics2D.GetRayIntersection(ray);
         if (hit.collider != null){
            if(hit.collider.gameObject.name == gameObject.name){
                Debug.Log("test");
            }
         }
     
    }
}

