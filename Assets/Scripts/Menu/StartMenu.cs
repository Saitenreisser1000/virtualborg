using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    GameObject progress;
    AsyncOperation async;

    private void Start()
    {
        progress = GameObject.Find("Progress");
    }

    public void ActivatePreloadedScene()
    {
        async = SceneManager.LoadSceneAsync(1);
    }

    private void Update()
    {
        string prog = (async.progress * 100).ToString() + "%";
        progress.GetComponent<UnityEngine.UI.Text>().text = prog;
    }

    public void GotoSite()
    {
        Application.OpenURL("https://www.borgleon.at/play/");
    }
}
