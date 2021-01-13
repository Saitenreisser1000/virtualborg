using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlBtn : MonoBehaviour
{
    RectTransform rectTrans;
    Button button;
    // Start is called before the first frame update
    void Start()
    {
        button = gameObject.GetComponent<Button>();
        rectTrans = gameObject.GetComponent<RectTransform>();
    }

    public void ActivateButton()
    {
        button.image.color = new Color(255f, 255f, 255f, 1f);
        button.GetComponent<HoverButton>().enabled = false;
    }

    public void DeactivateButton()
    {
        button.image.color = new Color(255f, 255f, 255f, .3f);
        button.GetComponent<HoverButton>().enabled = true;
    }
}
