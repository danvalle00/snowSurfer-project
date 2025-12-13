using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerController : MonoBehaviour
{
    InputAction moveAction;
    Rigidbody2D playerRb;
    [SerializeField] float torqueAmount = 1f;

    private void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        playerRb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector2 movementInput = moveAction.ReadValue<Vector2>();
        playerRb.AddTorque(-movementInput.x * torqueAmount);

    }

}
