using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NavDropdown : MonoBehaviour
{
    public GameObject pauseMenu;
    GameObject player;
    GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    public void FindRoom(string name)
    {
        if (name == "Abbrechen")
        {
            player.SendMessage("RemoveTarget");
            return;
        }
        target = GameObject.Find(name);
        player.SendMessage("NavigationTarget", target);
        pauseMenu.SendMessage("GameRun");
    }
}
