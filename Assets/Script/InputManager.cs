using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInput.OnFootActions onFoot;
    
    private PlayerMotor motor;
    private PlayerLook look;
    private void Awake()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;
        
        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();
        
        onFoot.Jump.performed += ctx => motor.Jump();
        
        onFoot.Crouch.performed += ctx => motor.Crouch();
        onFoot.Sprint.performed += ctx => motor.Sprint();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //tell player motor to move using the value from out movement action 
        motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
        
    }
    
    void LateUpdate()
    {
        //tell player motor to look using the value from out movement action 
        look.ProcessLook(onFoot.Look.ReadValue<Vector2>());
        
    }
    
    private void OnEnable()
    {
        onFoot.Enable();
    }
    
    private void OnDisable()
    {
        onFoot.Disable();
    }
}
