using System.Collections.Generic;
using UnityEngine;

public class TemperatureManager : MonoBehaviour
{
    // Singleton instance
    public static TemperatureManager temperatureControl { get; private set; }

    // Members
    private List<IHeatable> _heatables = new List<IHeatable>();

    // Unity Lifecycle
    void Awake()
    {
        if (temperatureControl != null && temperatureControl != this)
        {
            Destroy(gameObject);
            return;
        }

        temperatureControl = this;
    }
    void Start()
    {
        InvokeRepeating("NatureTemperatureDegrading", 1f, 1f);
    }

    // Methods
    public void Unregister(IHeatable heatable) => _heatables.Remove(heatable);
    public void Register(IHeatable heatable)
    {
        if (!_heatables.Contains(heatable)) _heatables.Add(heatable);
    }
    private void NatureTemperatureDegrading()
    {
        foreach (var heatable in _heatables)
        {
            heatable.TemperatureDown();
        }
    }
}
