using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;

public class BasicCharacter : MonoBehaviour
{
    protected MovementBehaviour _movementBehaviour;

    protected virtual void Awake()
    {
        _movementBehaviour = GetComponent<MovementBehaviour>();
    }
}
