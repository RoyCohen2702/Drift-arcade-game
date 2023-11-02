using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HUD : MonoBehaviour
{
    private UIDocument _attachDocument = null;
    private VisualElement _root = null;

    private ProgressBar _fuelBar = null;

    void Start()
    {
        _attachDocument = GetComponent<UIDocument>();
        if (_attachDocument)
        {
            _root = _attachDocument.rootVisualElement;
        }

        if (_root != null)
        {
            _fuelBar = _root.Q<ProgressBar>("FuelBar");

            PlayerCharacter player = FindObjectOfType<PlayerCharacter>();
            if (player != null)
            {
                Fuel playerFuel = player.GetComponent<Fuel>();
                if (playerFuel)
                {
                    UpdateFuel(playerFuel.MaxFuel, playerFuel.CurrentFuel);
                    playerFuel.OnFuelChanged += UpdateFuel;
                }
            }
        }
    }

    public void UpdateFuel(float maxFuel, float currentFuel)
    {
        if (_fuelBar == null)
        {
            return;
        }

        _fuelBar.value = currentFuel / maxFuel;
        _fuelBar.title = string.Format("{0}/{1}", currentFuel, maxFuel);
    }
}
