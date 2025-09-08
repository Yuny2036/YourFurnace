using System;
using Mono.Cecil.Cil;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    [Header("Locate a scene to go")]
    [Tooltip("At least one attribute must NOT be null!")]
    [SerializeField] private int sceneNumber;
    [Header("Opposit collider as a 'door'")]
    [Tooltip("Which collider will react this component?")]
    [SerializeField] private Collider opponent;

    void OnTriggerEnter(Collider other)
    {
        if (other == opponent)
        {
            SwitchScene(sceneNumber);
        }
    }

    public void SwitchScene(int sceneNumber)
    {
        if (sceneNumber >= 0)
        {
            SceneManager.LoadSceneAsync(sceneNumber);
        }

    }
}
