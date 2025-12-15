using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float torqueAmount = 1f;
    [SerializeField] private float baseSpeed = 15f;
    [SerializeField] private float boostedSpeed = 20f;
    [SerializeField] private ParticleSystem powerupEffect;
    private int powerupCount;

    private InputAction moveAction;
    private Rigidbody2D playerRb;
    private SurfaceEffector2D surfaceEffector;
    private Vector2 movementInput;
    private bool canControlPlayer = true;

    // flips
    private float previousRotation;
    private float totalRotation;


    // score
    private ScoreManager scoreManager;

    private void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        playerRb = GetComponent<Rigidbody2D>();
        surfaceEffector = FindFirstObjectByType<SurfaceEffector2D>();
        scoreManager = FindFirstObjectByType<ScoreManager>();
    }

    private void Update()
    {
        if (!canControlPlayer) { return; }
        RotatePlayer();
        BoostPlayer();
        CalculateFlips();
    }

    private void RotatePlayer()
    {
        movementInput = moveAction.ReadValue<Vector2>();
        playerRb.AddTorque(-movementInput.x * torqueAmount);
    }

    private void BoostPlayer()
    {
        movementInput = moveAction.ReadValue<Vector2>();
        surfaceEffector.speed = movementInput.y > 0 ? boostedSpeed : baseSpeed;
    }

    public void DisableControl()
    {
        canControlPlayer = false;
    }

    private void CalculateFlips()
    {
        float currentRotation = transform.rotation.eulerAngles.z;
        totalRotation += Mathf.DeltaAngle(previousRotation, currentRotation);
        if (totalRotation >= 340f || totalRotation <= -340f) // front and black flips
        {
            totalRotation = 0f;
            scoreManager.AddScore(100);
        }
        previousRotation = currentRotation;
    }

    public void ApplyPowerup(PowerSO powerUp)
    {
        powerupEffect.Play();
        powerupCount++;
        if (powerUp.GetPowerUpType == "speed")
        {
            baseSpeed += powerUp.GetValueChange;
            boostedSpeed += powerUp.GetValueChange;
        }
        else if (powerUp.GetPowerUpType == "torque")
        {
            torqueAmount += powerUp.GetValueChange;
        }
    }

    public void DeactivatePowerup(PowerSO powerUp)
    {
        powerupCount--;
        if (powerupCount <= 0)
        {
            powerupEffect.Stop();
        }
        if (powerUp.GetPowerUpType == "speed")
        {
            baseSpeed -= powerUp.GetValueChange;
            boostedSpeed -= powerUp.GetValueChange;
        }
        else if (powerUp.GetPowerUpType == "torque")
        {
            torqueAmount -= powerUp.GetValueChange;
        }
    }
}
