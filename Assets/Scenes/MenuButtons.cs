using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{

    public GameObject menu;
    public GameObject guide;
    public GameObject howto;
    public GameObject Pistas;


    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void goToGuide()
    {
        menu.SetActive(false);
        guide.SetActive(true);
        howto.SetActive(false);
    }
    public void goToHowto()
    {
        menu.SetActive(false);
        guide.SetActive(false);
        howto.SetActive(true);
    }

    public void goToMenu()
    {
        menu.SetActive(true);
        guide.SetActive(false);
        howto.SetActive(false);
        Pistas.SetActive(false);
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void goToPistas()
    {
        menu.SetActive(false);
        guide.SetActive(false);
        Pistas.SetActive(true);
    }
    
}
