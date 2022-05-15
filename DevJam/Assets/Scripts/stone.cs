using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stone : MonoBehaviour
{
    public GameObject goat;
    public goatController goatScript => goat.GetComponent<goatController>();
    
    private void Update()
    {
        if (goatScript.isStone && Vector2.Distance(gameObject.transform.position,goat.transform.position) < 10)
        {
            StartCoroutine(amkkodu());
        }
        
    }

    IEnumerator amkkodu()
    {
        GetComponent<Animator>().SetTrigger("isTas");
        yield return new WaitForSeconds(1.3f);
        gameObject.SetActive(false);
        
    }
}
