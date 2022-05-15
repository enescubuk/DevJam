using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneScript : MonoBehaviour
{
    [SerializeField] GameObject rabbit;
    [SerializeField] GameObject cat;
    [SerializeField] GameObject goat;
    [SerializeField] float fallValue;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RabbitFall();
        GoatFall();
        CatFall();
    }
    void RabbitFall()
    {

        if (rabbit.transform.position.y < fallValue)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    void GoatFall()
    {
        if (goat.transform.position.y < fallValue)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    void CatFall()
    {

        if (cat.transform.position.y < fallValue)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
