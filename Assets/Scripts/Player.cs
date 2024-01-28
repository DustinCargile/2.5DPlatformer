using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _controller;
    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private float _gravity = 1.0f;
    [SerializeField] private float _jumpHeight = 5.0f;

    private float _yVelocity;
    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {        
        var horizontal = InputManager.Instance.GetPlayerHorizontalMovement();
       
        
        Vector3 direction = new Vector3(horizontal,0,0);
        
        var velocity = direction * _speed;

        if (_controller.isGrounded)
        {
            _yVelocity = InputManager.Instance.GetPlayerJump() * _jumpHeight;
        }
        else 
        {
            _yVelocity -= _gravity;
        }
        velocity.y = _yVelocity;
        Move(velocity);
    
    }

    private void Move(Vector3 velocity)
    {
        _controller.Move(velocity * Time.deltaTime);

    }


    }
