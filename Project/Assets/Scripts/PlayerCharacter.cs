using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCharacter : BasicCharacter
{
    [SerializeField]
    private InputActionAsset _inputAsset;

    [SerializeField]
    private InputActionReference _movementAction;

    protected override void Awake()
    {
        base.Awake();

        if (_inputAsset == null) return;
    }

    private void OnEnable()
    {
        if (_inputAsset == null) return;
        _inputAsset.Enable();
    }

    private void OnDisable()
    {
        if (_inputAsset == null) return;
        _inputAsset.Disable();
    }

    private void Update()
    {
        HandleMovementInput();
    }

    void HandleMovementInput()
    {
        /*if (_movementBehaviour == null || _movementAction == null) return;

        float movementInput = _movementAction.action.ReadValue<float>();
        Vector3 movement = movementInput * Vector3.right;

        _movementBehaviour.DesiredMovementDirection = movement;*/
    }
}
