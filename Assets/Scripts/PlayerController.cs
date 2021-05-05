using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public SneakyBar SneakyBar;
    [SerializeField] private float speed;

    public float gems;
    public Text gemsDisplay;
    public GameObject inspect;
    private Color inspectAlpha;

    private PlayerMovements PlayerMovements;

    private Animator Animator;

    private SpriteRenderer SpriteRenderer;

    public GameObject inventoryHUD;
    public GameObject PauseMenu;
    [SerializeField]public bool IsPaused = true;

    

    private void Awake() {
        PlayerMovements = new PlayerMovements();
        Animator = GetComponent<Animator>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
        inspectAlpha = inspect.GetComponent<SpriteRenderer>().color;
        PauseMenu = GameObject.Find("PauseMenu");
        //DontDestroyOnLoad(inventoryHUD);

        
    }
    private void OnEnable() {
        PlayerMovements.Enable();
        PlayerMovements.Land.Interact.performed += _ => Interact();
        PlayerMovements.Land.PauseMenu.performed += _ => PauseGame();
    }
    private void OnDisable() {
        PlayerMovements.Disable();
    }
    void Start()
    {
        inspectAlpha.a = 0f;
        inspect.GetComponent<SpriteRenderer>().color = inspectAlpha;
    }

    // Update is called once per frame
    void Update()
    {
        gemsDisplay.text = gems.ToString();
        move();
    }

    private void Interact(){
        Debug.Log("test");
    }

    private void move(){
        if (IsPaused){
            float movementInput = PlayerMovements.Land.Move.ReadValue<float>();
            Vector3 currentPosition = transform.position;
            currentPosition.x += movementInput * speed * Time.deltaTime;
            transform.position = currentPosition;

            if (movementInput != 0 && PlayerMovements.Land.Sneak.ReadValue <float>() != 1){
                speed = 2;
                Animator.SetBool("Walk",true);
                }
            else Animator.SetBool("Walk",false);

            if (movementInput == 1) SpriteRenderer.flipX = false;
            else if (movementInput == -1)SpriteRenderer.flipX = true;

            if((movementInput == 1 && PlayerMovements.Land.Sneak.ReadValue <float>() == 1) ||(movementInput == -1 && PlayerMovements.Land.Sneak.ReadValue <float>() == 1) ) {
                Animator.SetBool("Run",true);
                speed =3;
                Detected();
            }
            else
                {
                    Animator.SetBool("Run",false);
                    unDetected();
                }
        }
    }

     public void PauseGame(){
        if(IsPaused){
            Time.timeScale = 0;
            IsPaused=false;
            PauseMenu.transform.Find("Menu").gameObject.SetActive(true);
        }
        else{
            Time.timeScale = 1;
            IsPaused = true;
            PauseMenu.transform.Find("Menu").gameObject.SetActive(false);
        }
     }

    float a=0;
    private void Detected(){
        if (a < 10){
        a += 0.03f;
        SneakyBar.setBar(a);
        }
        SneakyBar.gameover(a);
        
    }

    private void unDetected(){
        if (a  > 0){
        a -= 0.003f;
        SneakyBar.setBar(a);
        }
       
    }

    public void InspectBlink(bool show){
        inspectAlpha.a = show == true ? 1f : 0f;
        inspect.GetComponent<SpriteRenderer>().color = inspectAlpha;
        //StartCoroutine(Blinker());
        
    }
    public IEnumerator Blinker(){
         Color inspectColor = inspect.GetComponent<SpriteRenderer>().color;
         inspect.GetComponent<SpriteRenderer>().color = inspectColor;

         //inspectAlpha.a = 1f;
         //inspectColor = inspect.GetComponent<SpriteRenderer>().color;
         
        inspectColor.a = 0f;
        inspect.GetComponent<SpriteRenderer>().color = inspectColor;
        yield return new WaitForSeconds (0.5f);
        inspectColor.a = 1f;
        inspect.GetComponent<SpriteRenderer>().color = inspectColor;
        yield return new WaitForSeconds (1f);
        inspectColor.a = 0f;
        inspect.GetComponent<SpriteRenderer>().color = inspectColor;
        yield return new WaitForSeconds (1.5f);
        inspectColor.a = .8f;
        inspect.GetComponent<SpriteRenderer>().color = inspectColor;
        yield return new WaitForSeconds (2f);
        inspectColor.a = 0f;
        inspect.GetComponent<SpriteRenderer>().color = inspectColor;
        yield return new WaitForSeconds (2.5f);
        inspectColor.a = .7f;
        inspect.GetComponent<SpriteRenderer>().color = inspectColor;
        yield return new WaitForSeconds (3f);
        inspectColor.a = 0f;
        inspect.GetComponent<SpriteRenderer>().color = inspectColor;
        yield return new WaitForSeconds (3.5f);
        inspectColor.a = .4f;
        inspect.GetComponent<SpriteRenderer>().color = inspectColor;
        yield return new WaitForSeconds (4f);
        inspectColor.a = 0f;
        inspect.GetComponent<SpriteRenderer>().color = inspectColor;
         
         //Character.SetActive(false);
         StopCoroutine ("Blinker");
     }

}
