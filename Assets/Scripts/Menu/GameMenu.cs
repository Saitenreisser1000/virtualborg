using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu : MonoBehaviour
{
    public GameObject fullscreen;
    // Start is called before the first frame update
    void Start()
    {
        SetFullscreenActive(false);
    }

    public void SetFullscreenActive(bool active)
    {
        fullscreen.SetActive(active);
    }
}
