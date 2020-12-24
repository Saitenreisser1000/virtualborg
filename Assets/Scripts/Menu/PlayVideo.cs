using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayVideo : MonoBehaviour
{
    public bool autostart = false;
    private bool fullscreen = false;
    public bool isFullscreenable = true;
    public string song;
    public VideoPlayer videoPlayer;
    public int startFrame;
    private GameObject descriptionUI;

    // Start is called before the first frame update
    void Start()
    {
        descriptionUI = GameObject.Find("Fullscreen");
        videoPlayer = gameObject.GetComponent<VideoPlayer>();
        videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, song + ".mp4");
        videoPlayer.SetDirectAudioVolume(0, 0.05f);
        videoPlayer.SetDirectAudioMute(0, true);
        videoPlayer.Prepare();
        /*videoPlayer.Play();
        if (!autostart)
        {
            videoPlayer.frame = startFrame;
            videoPlayer.Pause();
        }*/
    }

    /*void StartVideoGesture()
    {
        videoPlayer.Play();
        if (!autostart)
        {
            videoPlayer.frame = startFrame;
            videoPlayer.Pause();
        }
    }*/

    private void Update()
    {
        if(!fullscreen && videoPlayer.isPlaying && Input.GetKeyDown(KeyCode.K) && isFullscreenable)
        {
            fullscreen = true;
            descriptionUI.GetComponent<UnityEngine.UI.Text>().text = "beliebige Taste";
            videoPlayer.renderMode = VideoRenderMode.CameraNearPlane;
            videoPlayer.targetCamera = GameObject.Find("FirstPersonCharacter").GetComponent<Camera>();
        }     

        else if (fullscreen && (Input.anyKeyDown || Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") !=  0))
        {
            descriptionUI.GetComponent<UnityEngine.UI.Text>().text = "(K) Fullscreen";
            videoPlayer.renderMode = VideoRenderMode.MaterialOverride;
            fullscreen = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        descriptionUI.GetComponent<UnityEngine.UI.Text>().text = "(K) Fullscreen";
        if(other.tag == "Player")
        {
            videoPlayer.SetDirectAudioMute(0, false);
            //StopAllCoroutines();
            //videoPlayer.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        descriptionUI.GetComponent<UnityEngine.UI.Text>().text = "";
        if (other.tag == "Player")
        {
            videoPlayer.SetDirectAudioMute(0, true);
            //videoPlayer.Pause();
            //StartCoroutine(SetVideoBack());
        }
    }

    IEnumerator SetVideoBack()
    {
        yield return new WaitForSeconds(5);
        videoPlayer.frame = startFrame;
    }
}
