using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public GameObject startCanvas, optionsCanvas;
    public Animator Animator;
    private int levelToLoad;
    void Update()
    {
        
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
    
    
    public void playButton()
    {
        FadeToLevel(1);
    }
    public void optionsButton()
    {
        startCanvas.SetActive(false);
        optionsCanvas.SetActive(true);
    }
    public void quitButton()
    {
        Application.Quit();
    }

    public void backButton()
    {
        optionsCanvas.SetActive(false);
        startCanvas.SetActive(true);
        
    }
    
    

    
}
