using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerasettings : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Camera camera = GetComponent<Camera>();
        float[] distances = new float[32];
        distances[8] = 50;
        distances[9] = 100;
        distances[10] = 30;     //nearrender
        distances[11] = 50;     //midnearrender
        distances[12] = 80;     //midrender
        distances[13] = 100;    //farrender

        camera.layerCullDistances = distances;
    }
}
