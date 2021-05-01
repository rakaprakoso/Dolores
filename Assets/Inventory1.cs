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
        transform.localPosition = new Vector2(-400f-32.2f,0);
    }
    
    public void changepos(){
        if (hide){
            //transform.position = new Vector2(33.2f,transform.position.y);
            transform.localPosition = new Vector2(43.4f-400f,0);
            hide = false;
        }else{
            transform.localPosition = new Vector2(-400f-32.2f,0);
            //transform.position = new Vector2(-25.2f,transform.position.y);
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

    public void MoveLeft(RectTransform panel)
     {
         StartCoroutine(Move(panel, new Vector2(-1255, 0)));
     }
 
     IEnumerator Move(RectTransform rt, Vector2 targetPos)
     {
         float step = 0;
         while (step < 1)
         {
             rt.offsetMin = Vector2.Lerp(rt.offsetMin, targetPos, step += Time.deltaTime);
             rt.offsetMax = Vector2.Lerp(rt.offsetMax, targetPos, step += Time.deltaTime);
             Debug.Log(Time.deltaTime);
             yield return new WaitForEndOfFrame();
         }
     }

}

