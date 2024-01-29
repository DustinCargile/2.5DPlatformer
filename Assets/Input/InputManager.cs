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

    private bool _playerJump = false;
    private float _buttonPressTime = 0.01f;
    private Timer _timer;
    
    // Start is called before the first frame update
    void Start()
    {
        _input = new PlayerInputActions();
        _input.Player.Enable();
        _input.Player.Jump.performed += Jump_performed;
        _input.Player.Jump.canceled += Jump_canceled;
    }

    private void Jump_canceled(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        _playerJump = false;
    }

    private void Jump_performed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        _playerJump = true;
        StartCoroutine(TurnOffJump());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public float GetPlayerHorizontalMovement() 
    {
        return _input.Player.Movement.ReadValue<float>();
    }
    public bool GetPlayerJump() 
    {
        return _playerJump;
    }

    IEnumerator TurnOffJump() 
    {
        yield return new WaitForEndOfFrame();
        _playerJump = false;
    }
}
