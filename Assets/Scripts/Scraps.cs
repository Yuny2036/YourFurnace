using System;
using UnityEngine;

public class Scraps : MonoBehaviour, IHeatable, IHammerable
{
    [SerializeField] private PropsData propsData;
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
        hammerTrial = propsData.RequiredTrial;
        TemperatureManager.temperatureControl.Register(this);
    }

    void OnEnable()
    {
        
    }

    void OnDisable()
    {
        TemperatureManager.temperatureControl.Unregister(this);
    }

    public void TemperatureUp() => temparature += 400f * Time.deltaTime;
    public void TemperatureDown() => temparature -= 40f * Time.deltaTime;

    public void Hammer()
    {
        if (propsData.NextItem == null) return;

        Debug.Log(hammerTrial + ", " + temparature);
        if (temparature >= 800)
        {
            hammerTrial--;
        }

        if (hammerTrial <= 0)
        {
            GameObject newItem = Instantiate(propsData.NextItem, this.transform.position, this.transform.rotation);
            Destroy(gameObject);
        }
    }
}