using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GameObject title;
    public GameObject options;
    public GameObject credits;
    public GameObject exit;

    public void PlayGame()
    {

    }

    public void Options()
    {
        title.SetActive(false);
        options.SetActive(true);
    }

    public void OptionsOff()
    {
        options.SetActive(false);
        title.SetActive(true);
    }

    public void Credits()
    {
        title.SetActive(false);
        credits.SetActive(true);
    }

    public void CreditsOff()
    {
        credits.SetActive(false);
        title.SetActive(true);
    }

    public void ExitGame()
    {
        title.SetActive(false);
        exit.SetActive(true);
    }

    public void CancelExit()
    {
        exit.SetActive(false);
        title.SetActive(true);
    }

    public void YesExit()
    {
        Application.Quit();
    }
}
