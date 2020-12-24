using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSettings : MonoBehaviour
{
    bool isEasy = false;
    Component fpsController;
    Component easyController;
    // Start is called before the first frame update
    void Start()
    {
        fpsController = GetComponent("FirstPersonController");
        easyController = GetComponent("PlayerMovement");    
    }

    public void SetEasyControl(bool easy)
    {
        /*if (easy) {
            (fpsController as MonoBehaviour).enabled = false;
            (easyController as MonoBehaviour).enabled = true;

        }
        else
        {
            (fpsController as MonoBehaviour).enabled = true;
            (easyController as MonoBehaviour).enabled = false;
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.O))
        {
            SetEasyControl(isEasy);
            isEasy = !isEasy;
        }*/
    }
}
