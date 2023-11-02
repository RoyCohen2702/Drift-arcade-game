using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovementBehaviour : MonoBehaviour
{
    [SerializeField] protected float _moveSpeed = 20.0f;
    [SerializeField] protected float _steerAngle = 90f;
    [SerializeField] protected float _maxSpeed = 15.0f;

    protected float _currMoveSpeed = 0.0f;

    protected Rigidbody _rigidbody;
    protected Fuel _fuel;
    
    protected GameObject _target;
    public GameObject Target
    {
        get { return _target; }
        set { _target = value; }
    }

    protected Vector3 _desiredMovementDirection = Vector3.zero;
    public Vector3 DesiredMovementDirection
    {
        get { return _desiredMovementDirection; }
        set { _desiredMovementDirection = value; }
    }

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _fuel = GetComponent<Fuel>();
        _currMoveSpeed = _moveSpeed;
        
    }

    protected virtual void FixedUpdate()
    {
        HandleMovement();
    }

    protected virtual void HandleMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        DesiredMovementDirection +=  transform.forward * _currMoveSpeed  * Time.deltaTime;
        _rigidbody.AddForce(DesiredMovementDirection);
        _rigidbody.AddTorque(Vector3.up * horizontalInput * DesiredMovementDirection.magnitude * _steerAngle * Time.deltaTime);

        DesiredMovementDirection = Vector3.ClampMagnitude(DesiredMovementDirection, _maxSpeed);
        DesiredMovementDirection = Vector3.Lerp(DesiredMovementDirection.normalized, transform.forward, Time.deltaTime) * DesiredMovementDirection.magnitude;

    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (_rigidbody == null) { return; }

        /* if (collision.gameObject.CompareTag("StaticLevel") || collision.gameObject.CompareTag("Enemy"))
        {
            Kill();
            return;
        }

        if (collision.gameObject.CompareTag("Friendly")){
            Destroy(collision.gameObject);

            _currFuel += 20.0f;

            if (_currFuel > _fuelMax)
            {
                _currFuel = _fuelMax;
            }
        }*/

        switch (collision.gameObject.tag)
        {
            case "StaticLevel":
            case "Enemy":
                Kill();
                return;
            case "FuelLarge":
                Destroy(collision.gameObject);
                _fuel.PickupLarge();
                break;
            case "FuelMedium":
                Destroy(collision.gameObject);
                _fuel.PickupMedium();
                break;
            case "FuelSmall":
                Destroy(collision.gameObject);
                _fuel.PickupSmall();
                break;
            default:
                break;
        }
    }
    protected virtual void Kill()
    {
        Destroy(gameObject);
        SceneManager.LoadScene(0);
    }
}
