using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gampopup : MonoBehaviour
{

    public GameObject pauseMenu;

    private bool isPaused = false;


    // Start is called before the first frame update
    void Start()
    {
    

    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
                PauseGame();
            else
                ResumeGame();
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        isPaused = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        isPaused = false;
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
