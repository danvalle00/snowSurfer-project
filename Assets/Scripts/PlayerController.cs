using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float baseSpeed = 15f;
    [SerializeField] float boostedSpeed = 20f;

    private InputAction moveAction;
    private Rigidbody2D playerRb;
    private SurfaceEffector2D surfaceEffector;
    private Vector2 movementInput;
    private bool canControlPlayer = true;

    // flips
    private float previousRotation;
    private float totalRotation;
    private int flipCount = 0;

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
            flipCount++;
            totalRotation = 0f;
            scoreManager.AddScore(100);
        }
        previousRotation = currentRotation;
    }
}
