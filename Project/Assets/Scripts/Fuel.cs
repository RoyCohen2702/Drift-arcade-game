using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fuel : MonoBehaviour
{
    [SerializeField] private float _fuelRate = 5.0f;

    [SerializeField] private float _fuelSmall = 20.0f;
    [SerializeField] private float _fuelMedium = 50.0f;
    [SerializeField] private float _fuelLarge = 80.0f;

    private float _currentFuel;
    public float CurrentFuel { get { return _currentFuel; } }

    private float _maxFuel = 100.0f;
    public float MaxFuel { get { return _maxFuel; } }

    public delegate void FuelChange(float maxFuel, float currentFuel);
    public event FuelChange OnFuelChanged;
    void Awake()
    {
        _currentFuel = _maxFuel;
    }

    private void Update()
    {
        Drain();
    }

    private void Drain()
    {
        _currentFuel -= Time.deltaTime * _fuelRate;
        OnFuelChanged?.Invoke(_maxFuel, _currentFuel);
        if (_currentFuel <= 0)
        {
            Kill();
        }
    }

    public void PickupSmall() 
    {
        _currentFuel += _fuelSmall;
        OnFuelChanged?.Invoke(_maxFuel, _currentFuel);
        Over();
    }
    public void PickupMedium()
    {
        _currentFuel += _fuelMedium;
        OnFuelChanged?.Invoke(_maxFuel, _currentFuel);
        Over();
    }
    public void PickupLarge()
    {
        _currentFuel += _fuelLarge;
        OnFuelChanged?.Invoke(_maxFuel, _currentFuel);
        Over();
    }

    private void Over()
    {
        if (_currentFuel > _maxFuel)
        {
            _currentFuel = _maxFuel;
        }
    }

    void Kill()
    {
        Destroy(gameObject);
        SceneManager.LoadScene(0);
    }
}
