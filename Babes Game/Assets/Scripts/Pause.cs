using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    private bool isPaused;
    public GameObject pausePanel;

    void Start()
    {
        isPaused = false;
    }

    void Update()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            ChangePause();
        }
    }

    public void ChangePause()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void ExitGame()
    {
            Application.Quit();
    }

    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
        Time.timeScale = 1f;
    }
}
