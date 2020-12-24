using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInRoom : MonoBehaviour
{
    GameObject roomdisplay;

    // Start is called before the first frame update
    void Start()
    {
        roomdisplay = GameObject.Find("Roomdisplay");
    }

    void SetPlayerInRoom(string room)
    {
        roomdisplay.GetComponent<UnityEngine.UI.Text>().text = name;
    }

}
