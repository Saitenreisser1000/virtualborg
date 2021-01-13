using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class PlayVideo : MonoBehaviour
{
    public string song;
    private bool isLoaded = false;
    private bool fullscreen = false;
    private VideoPlayer videoPlayer;
    [SerializeField] private int startFrame;
    public bool isPlayerIn;
    private GameObject Scenemanager;
    private GameObject UserInt;

    void Start()
    {
        videoPlayer = gameObject.GetComponent<VideoPlayer>();
        Scenemanager = GameObject.Find("_SceneManagement");
        UserInt = GameObject.Find("_UI");
        
    }

    private void Update()
    {
        if(!fullscreen && isPlayerIn && Input.GetKeyDown(KeyCode.V))
        {
            SetFullScreenOnCamera(true); 
        }     

        else if (fullscreen && (Input.anyKeyDown))// || Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") !=  0))
        {
            SetFullScreenOnCamera(false);
        }
    }

    public void SetFullScreenOnCamera(bool toFull)
    {
        if (isPlayerIn)
        {
            if (toFull)
            {
                fullscreen = true;
                videoPlayer.renderMode = VideoRenderMode.CameraNearPlane;
                videoPlayer.targetCamera = GameObject.Find("FirstPersonCharacter").GetComponent<Camera>();
            }
            else
            {
                fullscreen = false;
                videoPlayer.renderMode = VideoRenderMode.MaterialOverride;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //descriptionUI.GetComponent<UnityEngine.UI.Text>().text = "(K) Fullscreen";
        if(other.tag == "Player")
        {
            if (!isLoaded)
            {
                videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, song + ".mp4");
                videoPlayer.SetDirectAudioVolume(0, 0.6f);
                videoPlayer.Prepare();
            }
            UserInt.SendMessage("SetFullscreenActive", true);
            Scenemanager.SendMessage("FadeOutMusic", 1);
            isPlayerIn = true;
            StopAllCoroutines();
            videoPlayer.Play();
            isLoaded = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //descriptionUI.GetComponent<UnityEngine.UI.Text>().text = "";
        if (other.tag == "Player")
        {
            UserInt.SendMessage("SetFullscreenActive", false);
            Scenemanager.SendMessage("FadeInMusic", 8);
            isPlayerIn = false;
            videoPlayer.Pause();
            StartCoroutine(SetVideoBack());
        }
    }

    IEnumerator SetVideoBack()
    {
        yield return new WaitForSeconds(5);
        videoPlayer.frame = startFrame;
    }

    public void SetVideoVolume(float vol)
    {
        //videoPlayer.SetDirectAudioVolume(0, vol);
    }
}
