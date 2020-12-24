using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigationSystem : MonoBehaviour
{
    //private NavMeshAgent agent;
    private NavMeshPath path;
    private LineRenderer line;
    private GameObject target;
    private List<Vector3> point;
    // Start is called before the first frame update
    void Start()
    {
        //agent = GetComponent<NavMeshAgent>();
        path = new NavMeshPath();
        line = GetComponent<LineRenderer>();
        if (target)
        {
            NavigationTarget(target);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            NavMesh.CalculatePath(transform.position, target.transform.position, NavMesh.AllAreas, path);
            line.positionCount = path.corners.Length;
            line.SetPositions(path.corners);
        }
        /*for (int i = 0; i < path.corners.Length - 1; i++)
        {
            Debug.DrawLine(path.corners[i], path.corners[i + 1], Color.red);
        }*/
    }

    void NavigationTarget(GameObject target)
    {
        this.target = target;
        Ray ray = Camera.main.ScreenPointToRay(target.transform.position);       
    }

    void RemoveTarget()
    {
        this.target = null;
        line.positionCount = 0;
    }

    void TriggeredRoom(GameObject room)
    {
        if(room == target)
        {
            RemoveTarget();
        }
    }
}
