using UnityEngine;
using UnityEngine.Rendering;

public interface IHammerable
{
    int HammerTrial { get; set; }
    public abstract void Hammer();
}
