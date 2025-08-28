using System.Collections.Generic;
using UnityEngine;

public class TemperatureManager : MonoBehaviour
{
    // Singleton instance
    public static TemperatureManager temperatureControl { get; private set; }
    
    // List of IHeatables
    private List<IHeatable> _heatables = new List<IHeatable>();

    void Awake()
    {
        if (temperatureControl != null && temperatureControl != this)
        {
            Destroy(gameObject);
            return;
        }

        temperatureControl = this;
        DontDestroyOnLoad(gameObject);
    }

    public void Register(IHeatable heatable)
    {
        if (!_heatables.Contains(heatable))
        {
            _heatables.Add(heatable);
        }
    }

    public void Unregister(IHeatable heatable)
    {
        _heatables.Remove(heatable);
    }

    void Update()
    {
        foreach (var heatable in _heatables)
        {
            heatable.TemperatureDown();
        }
    }
}
