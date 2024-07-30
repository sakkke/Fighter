using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    InputActionReference _move;

    [SerializeField]
    GameObject _player1;

    [SerializeField]
    Animator _player1Animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake()
    {
        _move.action.performed += OnMovePerform;
        _move.action.canceled += OnMoveCancel;
    }

    void Destroy()
    {
        _move.action.performed -= OnMovePerform;
        _move.action.canceled -= OnMoveCancel;
    }

    void OnEnable()
    {
        _move.action.Enable();
    }

    void OnDisable()
    {
        _move.action.Disable();
    }

    void OnMovePerform(InputAction.CallbackContext context)
    {
        var move = context.ReadValue<Vector2>();

        if (move.x > 0)
        {
            _player1Animator.SetBool("Walk Forward", true);
        }
        else
        {
            _player1Animator.SetBool("Walk Backward", true);
        }
    }

    void OnMoveCancel(InputAction.CallbackContext context)
    {
        _player1Animator.SetBool("Walk Forward", false);
        _player1Animator.SetBool("Walk Backward", false);
    }
}
