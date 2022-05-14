using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stone : MonoBehaviour
{
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
        StartCoroutine(cameraShake.Shake(.15f, -0.5f));
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
