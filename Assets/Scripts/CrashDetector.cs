using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float delayBeforeRestart = 1f;
    [SerializeField] private ParticleSystem crashEffect;
    private PlayerController playerController;

    private void Start()
    {
        playerController = FindFirstObjectByType<PlayerController>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        int layerIndex = LayerMask.NameToLayer("Floor");
        if (collision.gameObject.layer == layerIndex)
        {
            crashEffect.Play();
            playerController.DisableControl();
            Invoke("RestartLevel", delayBeforeRestart);
        }
    }

    void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }

}
