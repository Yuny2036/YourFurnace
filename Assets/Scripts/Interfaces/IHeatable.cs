using UnityEngine;

public interface IHeatable
{
    float Temparature { get; set; }

    public abstract void TemperatureUp();
    public abstract void TemperatureDown();
}
