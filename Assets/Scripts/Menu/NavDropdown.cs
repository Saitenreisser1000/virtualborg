using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NavDropdown : MonoBehaviour
{
    Dropdown navDropdown;
    GameObject player;
    GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        navDropdown = GetComponent<Dropdown>();
        navDropdown.onValueChanged.AddListener(delegate {
            DropdownValueChanged(navDropdown);
        });
    }

    void DropdownValueChanged(Dropdown change)
    {
        if(change.captionText.text == "Abbrechen")
        {
            player.SendMessage("RemoveTarget");
            return;
        }
        target = GameObject.Find("Nav" + change.captionText.text);
        //print("changed" + change.captionText.text);
        player.SendMessage("NavigationTarget", target);
    }
}
