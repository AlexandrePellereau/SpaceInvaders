using System;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public void StartClick()
    {
        Debug.Log("Start Clicked");
        UnityEngine.SceneManagement.SceneManager.LoadScene("Scenes/Main Game");
    }
    
    public void ShowCredits()
    {
        Invoke(nameof(LoadCredits), 3f);
    }
    
    public void LoadCredits()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Scenes/Credits");
    }
    
    private void LoadMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Scenes/Main Menu");
    }

    void Start()
    {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Credits")
        {
            Invoke(nameof(LoadMainMenu), 15f);
        }
    }
}
