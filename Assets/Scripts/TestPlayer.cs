using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestPlayer : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed = 5f;

    [SerializeField]
    private float _gravity = 9.81f;

    [SerializeField]
    private float _jumpSpeed = 3.5f;

    private CharacterController _controller;

    private Camera _camera;

    private float _directionY = 0;
    // Start is called before the first frame update
    void Start()
    {

        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, _directionY, verticalInput);

        if(Input.GetButtonDown("Jump"))
        {
            _directionY = _jumpSpeed;
        }


        _directionY -= _gravity * Time.deltaTime;

        direction.y = _directionY;

        _controller.Move(direction *  _moveSpeed * Time.deltaTime);

       
    }
}
