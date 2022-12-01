using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Tooltip("Maximum Movement Speed")]
    [Range(1f, 50f)]
    public float maxSpeed = 20f;

    [Tooltip("Maximum Angular Velocity")]
    [Range(1f, 50f)]
    public float maxAngularVelocity = 7f;

    [Tooltip("Player Controlled Acceleration")]
    [Range(1f, 200f)]
    public float acceleration = 1f;

    [Tooltip("Main Camera")]
    public Camera mainCamera;

    private Rigidbody _rigidBody;
    private PlayerInputActions _inputActions;
    private InputAction _move;

    void Awake()
    {
        _inputActions = new PlayerInputActions();
    }

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _move = _inputActions.Player.Move;
        _move.Enable();

    }

    void FixedUpdate()
    {
        _rigidBody.maxAngularVelocity = maxAngularVelocity;
        Vector2 inputVector = _move.ReadValue<Vector2>();
        Vector3 cameraForward = mainCamera.transform.forward;
        cameraForward.y = 0f;
        Vector3 cameraRight = mainCamera.transform.right;
        cameraRight.y = 0f;

        Vector3 movementVector = (cameraForward * inputVector.y) + (cameraRight * inputVector.x);
        _rigidBody.AddForce(movementVector.normalized * acceleration);
        _rigidBody.velocity = Vector3.ClampMagnitude(_rigidBody.velocity, maxSpeed);
    }

    void onEnable()
    {
        _move.Enable();
    }

    void onDisable()
    {
        _move.Disable();
    }
}
