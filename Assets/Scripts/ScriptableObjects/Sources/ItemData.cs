using UnityEngine;

public abstract class ItemData : ScriptableObject
{
    [Header("General Stats")]
    public string ItemName;
    public int Value;
    public GameObject ThisPrefab;
    [Header("Enhancement-related values")]
    public int RequiredTrial;
    public GameObject NextItem;
    public string FlavorText;
    [Header("Destroy Effect")]
    public GameObject FailureEffect = null;
    
}
