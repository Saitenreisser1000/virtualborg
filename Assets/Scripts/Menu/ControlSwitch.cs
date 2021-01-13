using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ControlSwitch : MonoBehaviour
{

    private GameObject mausAn;
    private GameObject mausAus;
    private GameObject touch;
    private GameObject player;
    public GameObject joystick;
    private Image joystickImage;

    // Start is called before the first frame update
    void Start()
    {
        mausAn = GameObject.Find("Maus an");
        mausAus = GameObject.Find("Maus aus");
        touch = GameObject.Find("Touch");
        joystickImage = joystick.GetComponentInChildren<Image>();
        player = GameObject.FindGameObjectWithTag("Player");
        player.SendMessage("SetToTouchMode");
        PressedButton(mausAus);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PressedButton(GameObject btn)
    {
        if(btn.name == "Maus an")
        {
            joystickImage.enabled = false;
            mausAus.SendMessage("DeactivateButton");
            touch.SendMessage("DeactivateButton");
            btn.SendMessage("ActivateButton");

            player.SendMessage("SetToProMode");
        }
        if(btn.name == "Touch")
        {
            joystickImage.enabled = true;
            mausAn.SendMessage("DeactivateButton");
            mausAus.SendMessage("DeactivateButton");
            btn.SendMessage("ActivateButton");

            player.SendMessage("SetToTouchMode");
        }
        if (btn.name == "Maus aus")
        {
            joystickImage.enabled = false;
            touch.SendMessage("DeactivateButton");
            mausAn.SendMessage("DeactivateButton");
            btn.SendMessage("ActivateButton");

            player.SendMessage("SetToSimpleMode");
        }

    }
}
