using System;
using UnityEngine;

public class Shield : MonoBehaviour, IHeatable, IHammerable
{
    [SerializeField] private EquipmentData equipmentData;
    // Herited Members
    private int _hammerTrial;
    public int hammerTrial
    {
        get => _hammerTrial;
        set
        {
            _hammerTrial = value < 0 ? 0 : value;
        }
    }

    private float _temparature;
    public float temparature
    {
        get => _temparature;
        set
        {
            _temparature = Math.Clamp(value, 16f, 1400.00f);
        }
    }


    void Start()
    {
        temparature = 16f;
        hammerTrial = equipmentData.RequiredTrial;
        TemperatureManager.temperatureControl.Register(this);
    }

    void OnEnable()
    {

    }

    void OnDisable()
    {
        TemperatureManager.temperatureControl.Unregister(this);
    }

    public void TemperatureUp() => temparature += 300f * Time.deltaTime;
    public void TemperatureDown() => temparature -= 30f * Time.deltaTime;

    public void Hammer()
    {
        if (equipmentData.NextItem == null) return;

        if (temparature >= 800)
        {
            hammerTrial--;
        }

        if (hammerTrial <= 0)
        {
            if (GameManager.instance.IsSuccess(equipmentData.EnhanceChance))
            {
                GameObject newItem = Instantiate(equipmentData.NextItem, this.transform.position, this.transform.rotation);
                Destroy(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
