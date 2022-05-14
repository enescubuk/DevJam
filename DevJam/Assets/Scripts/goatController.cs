using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goatController : MonoBehaviour
{

    [SerializeField] private float RayOffset; 
    //Length of the ray
    public float laserLengthRight = 0.3f;
    public float laserLengthLeft = 0.3f;
    public float laserLengthDown = 0.03f;

    public bool isHitRight;
    public bool isHitLeft;
    public bool isHitDown;

    public Vector3 jump;
    public float jumpForce = 2.0f;
    public Vector2 maxSpeed;

    private bool isGroundedDown = true;
    private bool isGroundedLeft = true;
    private bool isGroundedRight = true;
    [SerializeField] float speed;
    Rigidbody2D rb => GetComponent<Rigidbody2D>();
    public Animator anim;
    GameObject ChildGameObject1 => transform.GetChild(0).gameObject;
    void Start()
    {
        
    }

    public void ControlRays()
    {

        //Get the first object hit by the ray
        RaycastHit2D hitRight = Physics2D.Raycast(new Vector3(transform.position.x + RayOffset, transform.position.y, transform.position.z), Vector2.right, laserLengthRight);

        RaycastHit2D hitLeft = Physics2D.Raycast(new Vector3(transform.position.x - RayOffset, transform.position.y, transform.position.z), Vector2.left, laserLengthLeft);

        RaycastHit2D hitDown = Physics2D.Raycast(new Vector3(transform.position.x, transform.position.y - RayOffset, transform.position.z), Vector2.down, laserLengthDown);

        //If the collider of the object hit is not NUll
        if (hitDown.collider != null)
        {
            //Hit something, print the tag of the object
            Debug.Log("Hitting: " + hitDown.collider.tag);
            if (isGroundedLeft!=true && isGroundedRight!=true)
            {
                isGroundedDown = true;
            }
            isHitDown = true;

        }
        else
        {
            isGroundedDown = false;
            isHitDown = false;
        }
        

        if (hitLeft.collider != null)
        {
            //Hit something, print the tag of the object

            Debug.Log("Hitting: " + hitLeft.collider.tag);
            if (isGroundedRight!=true)
            {
                isGroundedLeft = true;
                Debug.Log("solzıplama");
            }
            isHitLeft = true;

        }
        else
        {
            isGroundedLeft = false;
            isHitLeft = false;
        }

        if (hitRight.collider != null)
        {
            //Hit something, print the tag of the object
            Debug.Log("Hitting: " + hitRight.collider.tag);
            if (isGroundedLeft!=true)
            {
                isGroundedRight = true;
            }
            isHitRight = true;
        }
        else
        {
            isGroundedRight = false;
            isHitRight = false;
        }
        //Method to draw the ray in scene for debug purpose
        Debug.DrawRay(new Vector3(transform.position.x +0.7f, transform.position.y, transform.position.z), Vector2.right * laserLengthRight, Color.red);
        Debug.DrawRay(new Vector3(transform.position.x - 0.5f, transform.position.y, transform.position.z), Vector2.left * laserLengthLeft, Color.red);
        Debug.DrawRay(new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z), Vector2.down * laserLengthDown, Color.red); 

    }
    
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isHitDown)
        {
            if (isGroundedDown)
            {
                Debug.Log(0);
                jump.x = 0;
                jump.y = 2;
                rb.AddForce(jump * jumpForce, ForceMode2D.Impulse);
                anim.SetTrigger("isGoatJump");
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) && isHitLeft)
        {
            if (isGroundedLeft || isGroundedDown!=true)
            {
                Debug.Log(1);
                jump.y = 3;
                jump.x = 2;
                rb.AddForce(jump * jumpForce, ForceMode2D.Impulse);
                anim.SetTrigger("isGoatJump");
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) && isHitRight)
        {
            if (isGroundedRight || isGroundedDown!=true)
            {
                jump.y = 3;
                jump.x = -2;
                Debug.Log(2);
                rb.AddForce(jump * jumpForce, ForceMode2D.Impulse);
                anim.SetTrigger("isGoatJump");
            }
        }
    }
    void Update()
    {
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("GoatKafa") == false)
        {
            Movement();
            ControlRays();
            Jump();
            headOf();
        }

    }
    void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        if (horizontal < 0)
        {
            ChildGameObject1.GetComponent<SpriteRenderer>().flipX = true;
            anim.SetBool("isGoatRun", true);
        }
        if (horizontal > 0)
        {
            ChildGameObject1.GetComponent<SpriteRenderer>().flipX = false;
            anim.SetBool("isGoatRun", true);
            
        }
        if (horizontal == 0)
        {
            anim.SetBool("isGoatRun", false);
        }
        Vector3 movement = new Vector3(horizontal * speed, 0.0f);

        //rb.velocity = new Vector2(movement.x,0); 
        rb.AddForce(movement);
        if (rb.velocity.x > maxSpeed.x)
        {
            rb.velocity = new Vector2(maxSpeed.x,rb.velocity.y);
        }
        if (rb.velocity.x < -maxSpeed.x)
        {
            rb.velocity = new Vector2(-maxSpeed.x, rb.velocity.y);

        }
    }

    void headOf()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            anim.SetTrigger("isGoatKafa");
        }

    }

    
}
