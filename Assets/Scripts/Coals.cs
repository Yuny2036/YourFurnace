using System.Collections.Generic;
using UnityEngine;

public class Coals : MonoBehaviour
{
    private List<IHeatable> _heatables = new List<IHeatable>();

    // Register
    void OnTriggerEnter(Collider other)
    {
        other.gameObject.TryGetComponent<IHeatable>(out var heatable);
        if (heatable != null && !_heatables.Contains(heatable))
        {
            _heatables.Add(heatable);
        }
    }

    // Unregister
    void OnTriggerExit(Collider other)
    {
        other.gameObject.TryGetComponent<IHeatable>(out var heatable);
        _heatables.Remove(heatable);
    }

    void Update()
    {
        foreach (var heatable in _heatables)
        {
            heatable.TemperatureUp();
        }
    }
}
