using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator Animator;
    private int levelToLoad;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            FadeToLevel(1);
        }
    }

    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        Animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplate()
    {
        SceneManager.LoadScene(levelToLoad);
    } 

    
}
