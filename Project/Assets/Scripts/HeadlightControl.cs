using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadlightControl : MonoBehaviour
{
    public List<Light> _headlights;

    public void TurnOffHeadlights()
    {
        foreach(Light light in _headlights)
        {
            light.enabled = false;
        }
    }
}
