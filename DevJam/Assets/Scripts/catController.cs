using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class catController : MonoBehaviour
{
    public bool nextLevel;
    public Animator treeAnimator;
    public float speed = 2;
    float RayOffset = 1; 
    //Length of the ray
    float laserLengthRight = 0.1f;
    float laserLengthLeft = 0.1f;
    float laserLengthDown = 0.1f;

    public bool isHitRight;
    public bool isHitLeft;
    public bool isHitDown;

    Vector3 jump = new Vector3(0,2,0);
    float jumpForce = 2.0f;
    Rigidbody2D rb => GetComponent<Rigidbody2D>();

    Animator anim => GetComponent<Animator>();
    SpriteRenderer spriteRenderer => GetComponent<SpriteRenderer>();
    bool canClimb;
    public float treeOffsetX,treeOffsetY;
    Vector3 treePos;
    Vector2 maxSpeed = new Vector2(4,0);

    private Vector3 endPosition = new Vector3(5, -2, 0);
    private Vector3 startPosition;
    private float desiredDuration = 1.25f;
    private float elapsedTime;
    bool lerpClimb;
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
            
            //hitRight.collider.transform.GetChild(0).transform.position = new Vector3(5.0f, 3.0f, 0.0f);
            isHitRight = true;
        }
        else isHitRight = false;
        //Method to draw the ray in scene for debug purpose
        Debug.DrawRay(new Vector3(transform.position.x + RayOffset, transform.position.y, transform.position.z), Vector2.right * laserLengthRight, Color.red);
        Debug.DrawRay(new Vector3(transform.position.x - RayOffset, transform.position.y, transform.position.z), Vector2.left * laserLengthLeft, Color.red);
        Debug.DrawRay(new Vector3(transform.position.x, transform.position.y - RayOffset, transform.position.z), Vector2.down * laserLengthDown, Color.red); 


        
    }
    
    void Jump()
    {

            if (Input.GetKeyDown(KeyCode.Space) && isHitDown)
            {
                Debug.Log(0);
                rb.AddForce(jump * jumpForce, ForceMode2D.Impulse);
                anim.SetTrigger("catJump");
            }

    }
    
    void Climb()
    {
        if (canClimb)
        {
            Debug.Log("içerdeyim baba");
            if (Input.GetKeyDown(KeyCode.F))
            {
                lerpClimb = true;
                startPosition = transform.position;
                spriteRenderer.enabled = false;
                //transform.position = new Vector3(treePos.x + treeOffsetX ,treePos.y + treeOffsetY,treePos.z);
                treeAnimator.SetTrigger("climb");
                StartCoroutine(waitForClimb());
                

            }
            
        }
        
    }

    void animControls()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            spriteRenderer.flipX = false;
            anim.SetBool("catWalk",true);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            spriteRenderer.flipX = true;
            anim.SetBool("catWalk", true);
        }

        if (Input.GetAxis("Horizontal") == 0)
        {
            anim.SetBool("catWalk", false);
        }
        
    }
    void charMove()
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
        Vector3 movement = new Vector3(horizontal * speed, 0.0f);

        rb.AddForce(movement);

    }

    void Update()
    {

        ControlRays();
        Jump();
        animControls();
        charMove();
        Climb();
        if (lerpClimb == true)
        {
            elapsedTime += Time.deltaTime;
        float percentageComplete = elapsedTime / desiredDuration;
    
        transform.position = Vector3.Lerp(startPosition, new Vector3(treePos.x + treeOffsetX ,treePos.y + treeOffsetY,treePos.z), percentageComplete);
        }
    }

    IEnumerator waitForClimb()
    {
        yield return new WaitForSecondsRealtime(1.25f);
        spriteRenderer.enabled = true;
        lerpClimb = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        canClimb = true;
        treePos = other.transform.position;
        treeAnimator = other.GetComponent<Animator>();
    }
    void OnTriggerExit2D(Collider2D other)
    {
        canClimb = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Flag")
        {
            nextLevel = true;
        }
    }
}
