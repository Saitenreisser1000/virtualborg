using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController _controller;
    public float _speed = 1;
    public float _rotationSpeed = 0;

    private Vector3 rotation;

    public void Start()
    {
        _controller = gameObject.GetComponent<CharacterController>();
    }

    public void FixedUpdate()
    {
        this.rotation = new Vector3(0, Input.GetAxisRaw("Horizontal") /** _rotationSpeed * Time.deltaTime*/, 0);

        Vector3 move = new Vector3(0, -9.81f, Input.GetAxisRaw("Vertical") * Time.deltaTime);
        move = this.transform.TransformDirection(move);
        _controller.Move(move * _speed);
        this.transform.Rotate(this.rotation);
    }
}
