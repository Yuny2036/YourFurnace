using System;
using UnityEngine;

public class Scraps : PropsItem, IHeatable, IHammerable
{
    // Herited Members
    public int HammerTrial { get; set; }

    // Properties
    public float Temparature
    {
        get => _Temparature;
        set
        {
            _Temparature = Math.Clamp(value, 16f, 1400.00f);
        }
    }

    // Unity Lifecycle
    void Start()
    {
        Temparature = 16f;
        HammerTrial = propsData.RequiredTrial;
        TemperatureManager.temperatureControl.Register(this);
    }
    void OnDisable()
    {
        TemperatureManager.temperatureControl.Unregister(this);
    }

    // Methods
    public void TemperatureUp() => Temparature += 400f * Time.deltaTime;
    public void TemperatureDown() => Temparature -= 40f * Time.deltaTime;

    public void Hammer()
    {
        if (propsData == null) throw new NullReferenceException($"No props data has been set on {gameObject}");

        if (Temparature >= 800) HammerTrial--;

        if (HammerTrial <= 0)
        {
            GameObject newItem = Instantiate(propsData.NextItem, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    // internal fields
    private float _Temparature;
}