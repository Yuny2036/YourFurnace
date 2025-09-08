using System;
using UnityEngine;

public class Shield : EquipmentItem, IHeatable
{
    // Serialized Fields

    // Properties
    public float Temparature
    {
        get => _Temparature;
        set
        {
            _Temparature = Math.Clamp(value, 16f, 1400.00f);
        }
    }
    public float Empowered { get; set; } = 0.0f; // Enhancement success chance additor.


    // Unity Lifecycle
    void Start()
    {
        Initializer();
        
        Temparature = 16f;
        TemperatureManager.temperatureControl.Register(this);
    }
    void OnDisable()
    {
        TemperatureManager.temperatureControl.Unregister(this);
    }

    // Methods
    public void TemperatureUp() => Temparature += 300f * Time.deltaTime;
    public void TemperatureDown() => Temparature -= 30f * Time.deltaTime;

    public override void Hammer()
    {
        base.Hammer();

        if (Temparature >= 800)
        {
            HammerTrial--;
        }

        if (HammerTrial <= 0)
        {
            if (GameManager.instance.IsSuccess(equipmentData.EnhanceChance, Empowered))
            {
                // SUCCESS
                GameObject newItem = Instantiate(equipmentData.NextItem, transform.position, Quaternion.identity);
                GameObject successFX = Instantiate(equipmentData.Effect, transform.position, Quaternion.identity);
                Destroy(successFX, 1.8f);
                Destroy(gameObject);
            }
            else
            {
                // FAIL
                GameObject failFX = Instantiate(equipmentData.FailureEffect, transform.position, Quaternion.identity);
                Destroy(failFX, 1.8f);
                Destroy(gameObject);
            }
        }
    }

    // Internal Fields
    private float _Temparature;
}
