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

    Rigidbody2D rb => GetComponent<Rigidbody2D>();
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
            Debug.Log(0);
            rb.AddForce(jump * jumpForce, ForceMode2D.Impulse);
            }

    }

    void Update()
    {
        ControlRays();
        Jump();
    }
}
