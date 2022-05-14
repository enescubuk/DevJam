using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody2D rb;
    
    void Start () 
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update () 
    {
        float horizontal = Input.GetAxis("Horizontal");
        if (horizontal < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        Vector3 movement = new Vector3(horizontal*speed, 0.0f);
        
        rb.AddForce(movement);
    }
}
