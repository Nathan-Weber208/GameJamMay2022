using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    public float MovementSpeed;
    public float ExteriorRange;
    public float InteriorRange;
    public float Acceleration;
    private Vector2 MovementDirection;

    private GameObject player;


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
        player = GameObject.Find("player");
        // float Horizontal = Input.GetAxisRaw("Horizontal");
        // float Vertical = Input.GetAxisRaw("Vertical");
        // Debug.Log(transform.position);

        if (player == null){
            rb.velocity = new Vector2(0,0);
            return;}
        
        // Focuses attention onto the player.
        // MovementDirection = player.transform.position - transform.position;
        // MovementDirection.magnitude <= InteriorRange
        // rb.velocity = MovementDirection * MovementSpeed * Time.fixedDeltaTime;
        if (MovementDirection.magnitude <= InteriorRange)
        {
            MovementDirection = transform.position - player.transform.position;
            rb.velocity = MovementDirection * MovementSpeed * Time.fixedDeltaTime;
        }
        // else if (MovementDirection.magnitude < ExteriorRange && MovementDirection.magnitude > InteriorRange)
        // {
        //     MovementDirection = player.transform.position - transform.position;
        //     rb.velocity = Vector2.zero;
        // }
        else if (MovementDirection.magnitude >= ExteriorRange)
        {
            MovementDirection = player.transform.position - transform.position;
            rb.velocity = MovementDirection * MovementSpeed * Time.fixedDeltaTime;
        }
        else 
        {
            MovementDirection = player.transform.position - transform.position;
            rb.velocity = Vector2.zero;
        }
    }

    private void AccelerateTo(float DesiredVel)
    {
        if (rb.velocity.magnitude < DesiredVel)
        {
            // Speed up
            if (rb.velocity.magnitude > Acceleration)
            {
                rb.velocity -= rb.velocity.normalized * Acceleration;
            }
            else 
            {
                rb.velocity = Vector2.zero;
            }
        }
        else if (rb.velocity.magnitude > DesiredVel)
        {
            // Slow down
            if ((DesiredVel - rb.velocity.magnitude) > Acceleration)
            {
                rb.velocity += rb.velocity.normalized * Acceleration;
            }
            else 
            {
                rb.velocity = rb.velocity.normalized * DesiredVel;
            }
        }
    }

    private void Animate()
    {
        anim.SetFloat("MovementX", MovementDirection.x);
        anim.SetFloat("MovementY", MovementDirection.y);
    }
}
