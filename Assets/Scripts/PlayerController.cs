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

    private PlayerMovements PlayerMovements;

    private Animator Animator;

    private SpriteRenderer SpriteRenderer;

private void Awake() {
    PlayerMovements = new PlayerMovements();
    Animator = GetComponent<Animator>();
    SpriteRenderer = GetComponent<SpriteRenderer>();
}
private void OnEnable() {
    PlayerMovements.Enable();
}
private void OnDisable() {
    PlayerMovements.Disable();
}
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gemsDisplay.text = gems.ToString();
        move();
    }

    private void move(){
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
     float a=0;
    private void Detected(){
        if (a < 10){
        a += 0.03f;
        SneakyBar.setBar(a);
        }
    }

    private void unDetected(){
        if (a  > 0){
        a -= 0.003f;
        SneakyBar.setBar(a);
        }
       
    }
}
