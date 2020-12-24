using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PauseMenu : MonoBehaviour {

    bool firstStart = false;
    bool paused;
    bool isEasy = true;
    GameObject player;
    GameObject pauseMenu;
    GameObject playMenu;
    List<GameObject> videoplayer;
    [SerializeField] private GameObject canvas;

	void Start () {
        canvas.SetActive(true);
        player = GameObject.Find("Player");
        pauseMenu = GameObject.Find("PauseMenu");
        playMenu = GameObject.Find("PlayMenu");
        pauseMenu.SetActive(false);
        GamePause();

        videoplayer = new List<GameObject>(GameObject.FindGameObjectsWithTag("Videoplayer"));        
    }

    void Update () {
        if (Input.GetKeyDown("p"))
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

    public void SetEasyControl(bool easy)
    {
        isEasy = easy;
    }

    //to pause
    void GamePause()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        player.GetComponent<FirstPersonController>().enabled = false;
        player.GetComponent<PlayerMovement>().enabled = false;


        pauseMenu.SetActive(true);
        //playMenu.SetActive(false);

        paused = true;               
        Time.timeScale = 0;        
    }

    //to game
    void GameRun()
    {
        if (!firstStart)
        {
            FirstGamerInteraction();
            firstStart = true;
        }
        Cursor.lockState = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;

        //easy control switch
        if (isEasy)
        {
            player.GetComponent<FirstPersonController>().enabled = false;
            player.GetComponent<PlayerMovement>().enabled = true;

        }
        else
        {
            player.GetComponent<FirstPersonController>().enabled = true;
            player.GetComponent<PlayerMovement>().enabled = false;
        }

        pauseMenu.SetActive(false);
        //playMenu.SetActive(true);

        paused = false;
        Time.timeScale = 1;
    }

    //Triggered when Pausemenü is closed the first time
    void FirstGamerInteraction()
    {
        foreach(GameObject vp in videoplayer)
        {
            vp.SendMessage("StartVideoGesture");
        }
    }

    void VideoToFullscreen(bool full)
    {
        GameObject.Find("Fullscreen").SetActive(full);
    }

}
