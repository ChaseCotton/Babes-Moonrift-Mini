using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject buttonOne;
    public GameObject buttonTwo;
    public GameObject buttonThree;
    public GameObject buttonFour;

    public GameObject credits;

    public GameObject levels;

    public GameObject feedback;

    public void CreditsHUDEnter()
    {
        buttonOne.SetActive(false);
        buttonTwo.SetActive(false);
        buttonThree.SetActive(false);
        buttonFour.SetActive(false);

        credits.SetActive(true);
        levels.SetActive(false);
    }

    public void MenuHUDEnter()
    {
        buttonOne.SetActive(true);
        buttonTwo.SetActive(true);
        buttonThree.SetActive(true);
        buttonFour.SetActive(true);

        credits.SetActive(false);
        levels.SetActive(false);
        feedback.SetActive(false);
    }

    public void LevelsHUDEnter()
    {
        buttonOne.SetActive(false);
        buttonTwo.SetActive(false);
        buttonThree.SetActive(false);
        buttonFour.SetActive(false);

        credits.SetActive(false);
        levels.SetActive(true);
    }

    public void feedbackHUDEnter()
    {
        buttonOne.SetActive(false);
        buttonTwo.SetActive(false);
        buttonFour.SetActive(false);
        buttonThree.SetActive(false);

        credits.SetActive(false);
        levels.SetActive(false);
        feedback.SetActive(true);
    }

    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void QuitToDesktop()
    {
        Application.Quit();
    }
}
