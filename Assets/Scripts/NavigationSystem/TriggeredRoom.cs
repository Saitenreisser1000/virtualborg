using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggeredRoom : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.BroadcastMessage("TriggeredRoom", gameObject);
        }
    }
}
