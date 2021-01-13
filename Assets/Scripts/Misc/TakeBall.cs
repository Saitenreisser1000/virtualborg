using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeBall : MonoBehaviour
{
    Rigidbody rb;
    Transform parent;
    bool carry = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetMouseButtonDown(0))
        {
            rb.isKinematic = true;
            transform.SetParent(other.transform);
            parent = other.transform;
            carry = true;

        }
    }

    private void Update()
    {
        if (carry)
        {
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, (Screen.height / 2) - 200, Camera.main.nearClipPlane + 1));
            ToCarry();
        }
    }

    private void ToCarry()
    {
        if (Input.GetMouseButtonUp(0) && carry)
        {
            carry = false;
            rb.isKinematic = false;
            transform.SetParent(null);
            
            Vector3 pushDir = transform.position - Camera.main.transform.position;
            rb.AddForce(new Vector3(pushDir.normalized.x * 10, 20, pushDir.normalized.z), ForceMode.Impulse);
           
        }
    }
}
