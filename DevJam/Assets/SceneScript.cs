using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneScript : MonoBehaviour
{
    [SerializeField] GameObject rabbit;
    [SerializeField] float fallValue;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RabbitFall();
    }
    void RabbitFall()
    {

        if (rabbit.transform.position.y < fallValue)
        {
            Debug.Log(31);
        }
    }
}
