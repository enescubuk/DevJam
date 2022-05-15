using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial : MonoBehaviour
{
    bool girdi;
    public GameObject q,e,space,a,d;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        girdi = true;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        girdi = false;
    }
}
