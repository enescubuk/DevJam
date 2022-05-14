using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitController : MonoBehaviour
{

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

            isHitDown = true;

        }
        else isHitDown = false;

        if (hitLeft.collider != null)
        {
            //Hit something, print the tag of the object

            Debug.Log("Hitting: " + hitLeft.collider.tag);

            isHitLeft = true;

        }
        else isHitLeft = false;

        if (hitRight.collider != null)
        {
            //Hit something, print the tag of the object
            Debug.Log("Hitting: " + hitRight.collider.tag);

            isHitRight = true;
        }
        else isHitRight = false;
        //Method to draw the ray in scene for debug purpose
        Debug.DrawRay(new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z), Vector2.right * laserLengthRight, Color.red);
        Debug.DrawRay(new Vector3(transform.position.x - 0.5f, transform.position.y, transform.position.z), Vector2.left * laserLengthLeft, Color.red);
        Debug.DrawRay(new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z), Vector2.down * laserLengthDown, Color.red); 

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
        float horizontal = Input.GetAxis("Horizontal");
        if (horizontal < 0)
        {

            ChildGameObject1.GetComponent<SpriteRenderer>().flipX = true;
            anim.SetBool("isRabbitRun", true);

        }
        if (horizontal > 0)
        {
            ChildGameObject1.GetComponent<SpriteRenderer>().flipX = false;
            anim.SetBool("isRabbitRun", true);
            
        }
        if (horizontal == 0)
        {
            anim.SetBool("isRabbitRun", false);
        }
        Vector3 movement = new Vector3(horizontal * speed, 0.0f);

        //rb.velocity = movement;
        rb.AddForce(movement);
        
        Debug.Log(rb.velocity);
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
    }
    private void FixedUpdate()
    {
        //Jump();
    }
}
