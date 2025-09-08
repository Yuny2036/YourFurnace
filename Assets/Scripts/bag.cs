using UnityEngine;

public class bag : MonoBehaviour, IBreakable
{
    [SerializeField] private GameObject prefab;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Sword") Break();
    }

    public void Break()
    {
        var newScraps = Instantiate(prefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
