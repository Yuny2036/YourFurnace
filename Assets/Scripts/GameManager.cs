using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton Instance
    public static GameManager instance { get; private set; }

    // Private Data
    private EquipmentData _highestRecord;
    private int _goldHaving;
    private float _timeLeft;
    private System.Random random;

    // Public properties
    public int goldHaving
    {
        get => _goldHaving;
        set => _goldHaving = value < 0 ? 0 : value;
    }
    public float timeLeft
    {
        get => _timeLeft;
        set => _timeLeft = value < 0 ? 0 : value;
    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

        random = new System.Random();
    }

    public bool IsSuccess(float percentage)
    {
        if (random.NextDouble() * 100 < percentage) return true;
        return false;
    }
}
