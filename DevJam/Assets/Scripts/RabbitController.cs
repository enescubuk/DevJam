using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitController : MonoBehaviour
{
    public bool nextLevel;
    [SerializeField] private float RayOffset; 
    //Length of the ray
    public float laserLengthRight = 2f;
    public float laserLengthLeft = 2f;
    public float laserLengthDown = 2f;

    public bool isHitRight;
    public bool isHitLeft;
    public bool isHitDown;

    public Vector3 jump;
    public float jumpForce = 2.0f;

    [SerializeField] float speed;
    [SerializeField] Vector2 maxSpeed;

    [SerializeField] float fallValue;
    Rigidbody2D rb => GetComponent<Rigidbody2D>();
    private float nextActionTime = 0.0f;
    public float period = 0.1f;

    public Animator anim;
    public bool isPlayingRabbit;

    //GameObject ChildGameObject1 => transform.GetChild(0).gameObject;
    void Start()
    {
        nextLevel = false;
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
            

            isHitDown = true;

        }
        else isHitDown = false;

        if (hitLeft.collider != null)
        {
            //Hit something, print the tag of the object
            isHitLeft = true;

        }
        else isHitLeft = false;

        if (hitRight.collider != null)
        {
            //Hit something, print the tag of the object
            isHitRight = true;
        }
        else isHitRight = false;
        //Method to draw the ray in scene for debug purpose
        Debug.DrawRay(new Vector3(transform.position.x + +RayOffset, transform.position.y, transform.position.z), Vector2.right * laserLengthRight, Color.red);
        Debug.DrawRay(new Vector3(transform.position.x - +RayOffset, transform.position.y, transform.position.z), Vector2.left * laserLengthLeft, Color.red);
        Debug.DrawRay(new Vector3(transform.position.x, transform.position.y - +RayOffset, transform.position.z), Vector2.down * laserLengthDown, Color.red); 

    }
    
    void Jump()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) && isHitDown)
        {

            //StartCoroutine(isRabbitJumpCoroutine());

            rb.AddForce(jump * jumpForce, ForceMode2D.Impulse);

            anim.SetBool("isRabbitJump", true);
            
           
            
        }
        if (isHitDown == false)
        {
            anim.SetBool("isRabbitJump", true);
        }
        if (isHitDown)
        {
            anim.SetBool("isRabbitJump", false);
        }
    }

    
    void Movement()
    {
        float horizontal = 0f;
        if (Input.GetKey(KeyCode.A))
        {
            horizontal = -5;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            horizontal = 5f;
        }
        if (horizontal < 0)
        {   

            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            anim.SetBool("isRabbitRun", true);

        }
        if (horizontal > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            anim.SetBool("isRabbitRun", true);
            
        }
        if (horizontal == 0)
        {
            anim.SetBool("isRabbitRun", false);
        }
        Vector3 movement = new Vector3(horizontal * speed, 0.0f);

        //rb.velocity = movement;
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
    void Update()
    {
        anim.SetFloat("Blend", rb.velocity.y);
        Movement();
        ControlRays();
        Jump();
        if (Time.time > nextActionTime ) 
        {
            nextActionTime += period;
         // execute block of code here
            
            if (isHitDown == true && isPlayingRabbit == true && Input.GetAxis("Horizontal") != 0)
            {
                rb.AddForce(new Vector2(0,150));
            }
        }
    }
    private void FixedUpdate()
    {
        //Jump();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Flag")
        {
            nextLevel = true;
        }
    }
}
