using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCOP : BasicCharacter
{
    private GameObject _playerTarget = null;


    private void Start()
    {
        PlayerCharacter player = FindObjectOfType<PlayerCharacter>();

        if (player)
        {
            _playerTarget = player.gameObject;
        }
    }

    private void Update()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        if (_movementBehaviour == null)
        {
            return;
        }
        _movementBehaviour.Target = _playerTarget;
      
    }
}
