using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableUI : MonoBehaviour
{
    public GameObject setActive;
    // Start is called before the first frame update
    void Awake()
    {
        setActive.SetActive(true);
    }

}
