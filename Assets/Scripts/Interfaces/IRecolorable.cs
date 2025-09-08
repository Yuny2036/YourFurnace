using UnityEngine;

public interface IRecolorable
{
    // RendererInstance.material.color
    Color originalColor { get; set; }

    // Renderer of target or self
    Renderer targetRenderer { get; set; }

    public void InitializeColor();
    public void ResetColor();
    public void ChangeColor(float hueShiftAmount);
}
