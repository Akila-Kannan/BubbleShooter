using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{
    [SerializeField]private InputActionAsset inputActions;
    public InputAction lookAction;
    private Vector2 lookValue;
    public Action<Vector2> mousePos;
    private void OnEnable()
    {
        var playerActionMap = inputActions.FindActionMap("Player");
        lookAction = playerActionMap.FindAction("Look");

        lookAction.Enable();
        lookAction.performed += OnLookInput;
    }

    private void OnDisable()
    {
        lookAction.performed -= OnLookInput;
        lookAction.Disable();
    }

    public void OnLookInput(InputAction.CallbackContext context)
{
        lookValue = context.ReadValue<Vector2>();
        if (mousePos!= null)
            mousePos(lookValue);

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
