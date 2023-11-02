using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class navMeshmovementbehaviour : MovementBehaviour
{
    private NavMeshAgent _navMeshAgent;

    private Vector3 _previousTargetPosition = Vector3.zero;
    private bool _isAlive;

    protected override void Awake()
    {
        base.Awake();

        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.speed = _moveSpeed;
        _previousTargetPosition = transform.position;
    }

    const float MOVEMENT_EPSILON = 0.25f;

    protected override void HandleMovement()
    {
        if (_target == null)
        {
           _navMeshAgent.isStopped = true;
            return;
        }

        if ((_target.transform.position - _previousTargetPosition).sqrMagnitude > MOVEMENT_EPSILON)
        {
            _navMeshAgent.SetDestination(_target.transform.position);
            _navMeshAgent.isStopped = false;
            _previousTargetPosition = _target.transform.position;
        }
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        //base.OnCollisionEnter(collision);

        if (collision.gameObject.CompareTag("StaticLevel") || collision.gameObject.CompareTag("Enemy"))
        {
            _navMeshAgent.speed = 0;

            HeadlightControl headlightScript = GetComponentInChildren<HeadlightControl>();
            if (headlightScript != null)
            {
                headlightScript.TurnOffHeadlights();
            }
        }
    }
}
