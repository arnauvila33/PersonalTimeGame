using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro text;
    public static bool win = false;
    private bool paused = false;

    [SerializeField]
    private GameObject menu;

    

 
    

    // Update is called once per frame
    void Update()
    {
        int time = (60 - (int)Time.timeSinceLevelLoad);
        text.text = time.ToString();
        if (time <= 0&&!win)
        {
            SceneManager.LoadScene("Game");
        }
        if (win)
        {
            text.text = "";
        }
        if (Input.GetKeyDown(KeyCode.R)&&!win) {
            SceneManager.LoadScene("Game");
        }
        if (Input.GetKeyDown(KeyCode.P ))
        {
            if (!paused)
            {
                menu.SetActive(true);
                Time.timeScale = 0;
               
            }
            else
            {
                menu.SetActive(false);
                Time.timeScale = 1;
              
            }
            paused = !paused;
        }
        if (paused && Input.GetKeyDown(KeyCode.M))
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("Menu");
        }
        if (win && Input.GetKeyDown(KeyCode.M))
        {
            win = false;
            SceneManager.LoadScene("Menu");
        }
    }
}
