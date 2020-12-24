using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToRandomPoint : MonoBehaviour
{
    List<GameObject> pointList;
    Transform target;
    // Start is called before the first frame update
    void Start()
    {
        FindNewPoint();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, target.position) < 2)
        {
            FindNewPoint();
        }
    }

    void FindNewPoint()
    {
        
        pointList = new List<GameObject>(GameObject.FindGameObjectsWithTag("RandomPoint"));
        int rand = Random.Range(0,pointList.Count);
        target = pointList[rand].transform;
        transform.SendMessage("SetTarget", target);
    }
}
