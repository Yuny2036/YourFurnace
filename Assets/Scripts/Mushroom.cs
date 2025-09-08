using System;
using UnityEngine;

public class Mushroom : PropsItem, IHeatable
{
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
        TemperatureManager.temperatureControl.Register(this);
    }
    void OnDisable()
    {
        TemperatureManager.temperatureControl.Unregister(this);
    }
    
    void Update()
    {
        if (Temparature >= 1399.99f)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, 1f);

            foreach (var col in colliders)
            {
                if (
                    col.gameObject.GetComponent<IRecolorable>() == null &&
                    col.gameObject.GetComponent<IImbueable>() == null
                )
                {
                    continue;
                }

                var recolorable = col.gameObject.GetComponent<IRecolorable>();
                recolorable?.ChangeColor(0.3f);

                var rankable = col.gameObject.GetComponent<IImbueable>();
                rankable?.Imbue();

                break;
            }
            Destroy(gameObject);
        }
    }

    // Methods
    public void TemperatureUp() => Temparature += 400f * Time.deltaTime;
    public void TemperatureDown() => Temparature -= 40f * Time.deltaTime;

    // internal fields
    private float _Temparature;
}