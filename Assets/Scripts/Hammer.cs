using System;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    // External Assets
    [SerializeField] private AudioSource audioSourceHammer;
    [SerializeField] private AudioClip audioClipHammer;
    [SerializeField] private GameObject particlePrefab;

    // Hammer-Innate Members
    [SerializeField] private Collider hammerHead;
    public float hammerCooldown
    {
        get => _hammerCooldown;
        set
        {
            _hammerCooldown = Math.Max(value, 0.0f);
        }
    }

    // Unity Lifecycle
    void OnTriggerEnter(Collider other)
    {
        other.gameObject.TryGetComponent<IHammerable>(out var hammerable);
        if (hammerable != null && hammerCooldown <= 0.0f)
        {
            GameObject particle = Instantiate(particlePrefab,
            hammerHead.gameObject.transform.position,
            hammerHead.gameObject.transform.rotation
            );
            particle.transform.localScale *= 0.667f;
            Destroy(particle, 2.2f);

            audioSourceHammer.PlayOneShot(audioClipHammer);
            hammerable.Hammer();
            hammerCooldown = 0.5f;
        }
    }

    void Update()
    {
        hammerCooldown -= 0.5f * Time.deltaTime;
    }

    // Internal Fields
    private float _hammerCooldown;
}
