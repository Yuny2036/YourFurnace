using System;
using System.Collections.Generic;
using UnityEngine;

public class Coals : MonoBehaviour, IImbueable, IRecolorable
{
    // IRecolorable contracted property
    public Color originalColor
    {
        get => _originalColor;
        set
        {
            _originalColor = value;
        }
    }
    public Renderer targetRenderer
    {
        get => _targetRenderer;
        set { _targetRenderer = value; }
    }

    // Contracted and inherited internal fields
    private Color _originalColor;
    private Renderer _targetRenderer; // Coals targets itself; no need to show it on inspector.

    // Coals innate fields
    // IHeatable list
    private List<IHeatable> _heatables = new List<IHeatable>();
    public List<IHeatable> heatables { get; }

    // How much is this coals 'enhance' the enhancing chance?
    public float empoweringValue { get; private set; } = 0.0f;

    void Start()
    {
        InitializeColor();
    }

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

    // IRankable methods
    // 'enhancing' the enhancing chance by 2.4%p
    public void Imbue()
    {
        Debug.Log("Imbued!");
        empoweringValue += 2.4f;
    }


    //IRecolorable methods
    public void InitializeColor()
    {
        // Getting renderer
        // Debug.Log($"TargetRenderer is on {targetRenderer}");
        targetRenderer = GetComponent<Renderer>();
        if (targetRenderer == null) throw new Exception("Couldn't find any renderer component.");

        // Getting color from material; pink as fallback
        // Debug.Log($"OriginalColor was {targetRenderer.material.color.r}, {targetRenderer.material.color.g}, {targetRenderer.material.color.b}");
        originalColor = targetRenderer?.material.color ?? Color.pink;
    }

    public void ResetColor()
    {
        targetRenderer.material.color = originalColor != null ? originalColor : Color.pink;
    }

    public void ChangeColor(float amount)
    {
        // Need HSV to change only its hue.
        // Debug.Log($"{h}, {s}, {v}");
        Color.RGBToHSV(originalColor, out float h, out float s, out float v);

        // Hue circle range ::: 0.0f ~ 1.0f
        // Debug.Log($"New h value : {h}");
        h = (h + amount) % 1.0f;

        // Regain RGB data and give it.
        // Debug.Log($"Will be applied as : {newColor.r}, {newColor.g}, {newColor.b}");
        Color newColor = Color.HSVToRGB(h, s, v);

        targetRenderer.material.color = newColor;
    }
}
