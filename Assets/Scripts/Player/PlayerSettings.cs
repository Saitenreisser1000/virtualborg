using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

public class PlayerSettings : MonoBehaviour
{
    bool isEasy = false;
    float walkSpeed;
    float turnSpeed;
    Component fpsController;
    Component easyController;
    public GameObject volumeSlider;
    public GameObject drehenSlider;
    public GameObject laufenSlider;

    // Start is called before the first frame update
    void Start()
    {
        fpsController = GetComponent("FirstPersonController");
        easyController = GetComponent("PlayerMovement");
        GetVolume();
    }

    void GetVolume()
    {
        volumeSlider.GetComponent<Slider>().value = 0.5f;
    }

    void GetMovementSpeed(float speed)
    {
        walkSpeed = speed;
        laufenSlider.GetComponent<Slider>().value = speed;
    }

    void GetTurnSpeed(float speed)
    {
        turnSpeed = speed;
        drehenSlider.GetComponent<Slider>().value = speed;
    }
}
