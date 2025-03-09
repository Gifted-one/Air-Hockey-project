using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UIElements;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject PauseButton;
    public GameObject Gameover;
    public TextMeshProUGUI gameOvertext;
    public bool Paused;
    public bool IsPaused;
    PuckMovement puckMovement;
    public GameObject puckScript;
    public AudioSource Sound;
    public AudioClip SoundClip;
 

    void Start()
    {
        pauseMenu.SetActive(false);
        puckMovement = puckScript.GetComponent<PuckMovement>();
        Gameover.SetActive(false);
;
    }

    
    void Update()
    {
        if (Paused)
        {
            if (IsPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

        if (puckMovement.Playerscore == 5)
        {
            puckMovement.Playerscore = 0;
            Gameover.SetActive(true);
            Time.timeScale = 0f;
            gameOvertext.text = "You won! ^_^";
            Sound.clip = SoundClip;
            Sound.Play();
        }
        if (puckMovement.AIscore == 5)
        {
            puckMovement.AIscore = 0;
            Gameover.SetActive(true);
            Time.timeScale = 0f;
            gameOvertext.text = "You Lost! ^_^";

        }


    }

    public void pauseButton()
    {
        if (IsPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;

    }
    public void mainmenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }

    public void Quit()
    {
        Application.Quit();
    }




}

