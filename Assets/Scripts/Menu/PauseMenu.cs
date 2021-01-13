using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PauseMenu : MonoBehaviour {

    bool firstStart = false;
    bool paused;
    bool isEasy = false;

    GameObject player;
    GameObject pauseMenu;
    
    
    public GameObject navMenu;
    public GameObject creditMenu;
    public GameObject playMenu;

	void Start () {
        player = GameObject.Find("Player");
        pauseMenu = GameObject.Find("Mainmenu");
       
        navMenu.SetActive(false);
        creditMenu.SetActive(false);

        GamePause();

    }

    void Update () {
        if (Input.GetKeyDown("m"))
        {
            if (!paused)
            {
                GamePause();
            }
            else
            {
                GameRun();
            }
        }
	}

    public void PressedStartButton()
    {
        paused = !paused;
        GameRun();
    }

    public void GamePause()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        //player.SendMessage("PauseController");

        player.GetComponent<PlayerMovement>().enabled = false;


        pauseMenu.SetActive(true);
        //GetNavmenu();
        playMenu.SetActive(false);

        paused = true;               
        Time.timeScale = 0;        
    }

    //to game
    void GameRun()
    {
        if (!firstStart)
        {
            firstStart = true;
        }
        Cursor.lockState = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;

        //player.SendMessage("ActivateController");

        player.GetComponent<PlayerMovement>().enabled = true;

        pauseMenu.SetActive(false);
        navMenu.SetActive(false);
        creditMenu.SetActive(false);

        playMenu.SetActive(true);

        paused = false;
        Time.timeScale = 1;
    }

    public void CancelNavCredit()
    {
        navMenu.SetActive(false);
        creditMenu.SetActive(false);
    }

    public void GetNavmenu()
    {
        navMenu.SetActive(true);
        creditMenu.SetActive(false);
    }

    public void GetCreditMenu()
    {
        navMenu.SetActive(false);
        creditMenu.SetActive(true);
    }
}
