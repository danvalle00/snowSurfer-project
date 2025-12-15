using Unity.VisualScripting;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    [SerializeField] private PowerSO powerUp;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private SpriteRenderer powerupVisual;

    private float timeLeft;

    private void Start()
    {
        playerController = FindFirstObjectByType<PlayerController>();
        powerupVisual = GetComponentInChildren<SpriteRenderer>();
        timeLeft = powerUp.GetPowerUpDuration;
    }

    private void Update()
    {
        CountDownTimer();

    }

    private void CountDownTimer()
    {
        if (!powerupVisual.enabled && timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0)
            {
                playerController.DeactivatePowerup(powerUp);
            }

        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        int playerLayer = LayerMask.NameToLayer("Player");
        if (collision.gameObject.layer == playerLayer && powerupVisual.enabled)
        {
            playerController.ApplyPowerup(powerUp);
            powerupVisual.enabled = false;
        }
    }
}
