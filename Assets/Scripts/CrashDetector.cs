using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float delayBeforeRestart = 1f;
    [SerializeField] private ParticleSystem crashEffect;
    void OnTriggerEnter2D(Collider2D collision)
    {
        int layerIndex = LayerMask.NameToLayer("Floor");
        if (collision.gameObject.layer == layerIndex)
        {
            crashEffect.Play();
            Invoke("RestartLevel", delayBeforeRestart);
        }
    }

    void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }
}
