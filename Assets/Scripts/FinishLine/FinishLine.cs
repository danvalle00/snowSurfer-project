using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float delayBeforeRestart = 1f;
    [SerializeField] private ParticleSystem finishEffect;

    void OnTriggerEnter2D(Collider2D collision)
    {
        int layerIndex = LayerMask.NameToLayer("Player");
        if (collision.gameObject.layer == layerIndex)
        {
            finishEffect.Play();
            Invoke("RestartLevel", delayBeforeRestart);
        }
    }

    void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }
}