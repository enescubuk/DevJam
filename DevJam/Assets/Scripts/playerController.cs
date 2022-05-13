using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    [SerializeField] float Hiz;
    Rigidbody2D rb;

    void Start () 
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update () 
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0,7));
        }
        float yatay = Input.GetAxis("Horizontal");
        Vector3 hareket = new Vector3(yatay*Hiz, 0.0f); 
        rb.AddForce(hareket);
    }
}
