using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;

public class TouchControl : MonoBehaviour
{
    private CharacterController _controller;
    private GameObject player;
    public float _speed = 1;
    public float _rotationSpeed = 1;
    private Vector3 rotation;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        _controller = player.GetComponent<CharacterController>();
    }

    public void Update()
    {
        /*this.rotation = new Vector3(0, Input.GetAxisRaw("Horizontal") * _rotationSpeed * 30 * Time.deltaTime, 0);

        Vector3 move = new Vector3(0, -9.81f, Input.GetAxisRaw("Vertical") * Time.deltaTime);
        move = this.transform.TransformDirection(move);
        _controller.Move(move * _speed);
        this.transform.Rotate(this.rotation);*/
        
    }

    public void MoveUp()
    {
        
    }

    void MoveDown()
    {

    }

    void MoveLeft()
    {

    }

    void MoveRight()
    {

    }
}
