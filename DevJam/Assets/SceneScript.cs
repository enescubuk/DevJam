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
    [SerializeField] float damageValue = -12;

    public catController catScript => cat.GetComponent<catController>();
    public goatController goatScript => goat.GetComponent<goatController>();
    public RabbitController rabbitScript=> rabbit.GetComponent<RabbitController>();

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
        if (rabbitScript.nextLevel == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (rabbit.transform.position.y < fallValue)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (rabbit.GetComponent<Rigidbody2D>().velocity.y < damageValue && rabbitScript.isHitDown)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    void GoatFall()
    {
        if (goatScript.nextLevel == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (goat.transform.position.y < fallValue)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (goat.GetComponent<Rigidbody2D>().velocity.y < damageValue && goatScript.isHitDown)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    void CatFall()
    {
        if (catScript.nextLevel == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (cat.transform.position.y < fallValue)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
    }
}
