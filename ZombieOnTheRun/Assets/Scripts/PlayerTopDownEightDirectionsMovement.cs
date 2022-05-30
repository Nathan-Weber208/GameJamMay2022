using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTopDownEightDirectionsMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    public float MovementSpeed;
    private Vector2 MovementInput;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
        Animate();
    }

    private void Move()
    {
        float Horizontal = Input.GetAxisRaw("Horizontal");
        float Vertical = Input.GetAxisRaw("Vertical");

        if (Horizontal == 0 && Vertical == 0){
            rb.velocity = new Vector2(0,0);
            return;}
        
        MovementInput = new Vector2(Horizontal, Vertical);
        rb.velocity = MovementInput * MovementSpeed * Time.fixedDeltaTime;
    }

    private void Animate()
    {
        float Horizontal = Input.GetAxisRaw("Horizontal");
        float Vertical = Input.GetAxisRaw("Vertical");
        if(Horizontal == 0 && Vertical == 0){
            anim.SetFloat("Run", 0);
            anim.SetFloat("MovementX", MovementInput.x);
            anim.SetFloat("MovementY", MovementInput.y);  
        }
        else{
            anim.SetFloat("Run", 1);
            anim.SetFloat("MovementX", MovementInput.x);
            anim.SetFloat("MovementY", MovementInput.y);    
        }
        
    }
}
