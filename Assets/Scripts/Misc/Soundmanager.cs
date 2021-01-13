using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Soundmanager : MonoBehaviour
{
    private AudioSource audioSource;
    private float startVolume;
    private List<GameObject> videoplayers;
    
    //List<GameObject> videoplayer;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        startVolume = audioSource.volume;       
        videoplayers = new List<GameObject>(GameObject.FindGameObjectsWithTag("Videoplayer"));
        SetVolume(0.01f);
    }

    void SetVolume(float vol)
    {
        videoplayers.ForEach(vp => vp.SendMessage("SetVideoVolume", vol));
    }

    void FadeOutMusic(float time)
    {
        StopAllCoroutines();
        StartCoroutine(Fader(time, true));      
    }

    void FadeInMusic(float time)
    {
        StopAllCoroutines();
        StartCoroutine(Fader(time, false));
    }

    IEnumerator Fader(float FadeTime, bool fadeout)
    {
        if(fadeout)
        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;

            yield return null;
        }
        else
        {
            while (audioSource.volume < startVolume)
            {
                audioSource.volume += startVolume * Time.deltaTime / FadeTime;

                yield return null;
            }
        }
    }

    public void SetMonitorFullscreen()
    {
        videoplayers.ForEach(vp => vp.SendMessage("SetFullScreenOnCamera", true));
    }
}
