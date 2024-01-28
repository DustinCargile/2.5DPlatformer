using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    #region Singleton

    private static InputManager _instance;

    public static InputManager Instance { get 
        {
            if (_instance == null) 
            {
                _instance = new InputManager();
            }
            return _instance;
        }
        private set { _instance = value; }
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    #endregion

    private PlayerInputActions _input;
    // Start is called before the first frame update
    void Start()
    {
        _input = new PlayerInputActions();
        _input.Player.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float GetPlayerHorizontalMovement() 
    {
        return _input.Player.Movement.ReadValue<float>();
    }
    public float GetPlayerJump() 
    {
        return _input.Player.Jump.ReadValue<float>();
    }
}
