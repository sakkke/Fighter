using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    InputActionReference _move1;

    [SerializeField]
    InputActionReference _punch1;

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
        if (Input.GetKey(KeyCode.A))
        {
            _player1Animator.SetBool("Walk Backward", true);
        }
        else
        {
            _player1Animator.SetBool("Walk Backward", false);
        }

        if (Input.GetKey(KeyCode.D))
        {
            _player1Animator.SetBool("Walk Forward", true);
        }
        else
        {
            _player1Animator.SetBool("Walk Forward", false);
        }

        if (Input.GetKey(KeyCode.E))
        {
            _player1Animator.SetTrigger("PunchTrigger");
        }
    }

    void Awake()
    {
        _move1.action.performed += OnMovePerform;
        _move1.action.canceled += OnMoveCancel;

        _punch1.action.performed += OnPunchPerform;
    }

    void Destroy()
    {
        _move1.action.performed -= OnMovePerform;
        _move1.action.canceled -= OnMoveCancel;

        _punch1.action.performed -= OnPunchPerform;
    }

    void OnEnable()
    {
        _move1.action.Enable();
        _punch1.action.Enable();
    }

    void OnDisable()
    {
        _move1.action.Disable();
        _punch1.action.Disable();
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

    void OnPunchPerform(InputAction.CallbackContext context)
    {
        _player1Animator.SetTrigger("PunchTrigger");
    }
}
