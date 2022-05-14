using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stone : MonoBehaviour
{
    public Animator anim;
    public CameraShake cameraShake;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            StartCoroutine(stoneDestroy());
        }
    }

    IEnumerator stoneDestroy()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("GoatKafa") == true)
        {
            StartCoroutine(cameraShake.Shake(.15f, -0.5f));
            yield return new WaitForSeconds(1);
            Destroy(gameObject);
        }
    }
}
