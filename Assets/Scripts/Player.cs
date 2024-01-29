using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _controller;
    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private float _gravity = 1.0f;
    [SerializeField] private float _jumpHeight = 5.0f;

    private bool _spacePressed = false;
    private bool _canDoubleJump = false;
    private bool _didDoubleJump = false;

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

        /*if (_controller.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity = _jumpHeight;
                _canDoubleJump = true;
            }
            Debug.Log(InputManager.Instance.GetPlayerJump());            
        }
        else 
        {
            //check for Double Jump
            //current _yVelocity += jumpHeight
            if (Input.GetKeyDown(KeyCode.Space)) 
            {
                if (_canDoubleJump ) 
                {
                    DoubleJump();
                }
            }
            _yVelocity -= _gravity;
            

        }*/
        if (_controller.isGrounded)
        {
            if (InputManager.Instance.GetPlayerJump())
            {
                _yVelocity = _jumpHeight;
                _canDoubleJump = true;
            }
            Debug.Log(InputManager.Instance.GetPlayerJump());
        }
        else
        {
            //check for Double Jump
            //current _yVelocity += jumpHeight
            if (InputManager.Instance.GetPlayerJump())
            {
                if (_canDoubleJump)
                {
                    DoubleJump();
                }
            }
            _yVelocity -= _gravity;


        }
        velocity.y = _yVelocity;
        Move(velocity);

    
    }

    private void Move(Vector3 velocity)
    {
        _controller.Move(velocity * Time.deltaTime);

    }

    private void DoubleJump() 
    {
        _yVelocity += _jumpHeight * 1.5f;
        _canDoubleJump = false;
   

    }


    }
