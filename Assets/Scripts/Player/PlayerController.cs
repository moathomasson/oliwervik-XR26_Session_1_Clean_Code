using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float rotationSpeed = 0.5f;
    [SerializeField] private PlayerInput input;

    private Rigidbody rb;
    private Vector3 currentVelocity;
    private float yaw;
    private bool isGrounded = true;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void OnEnable()
    {
        input.OnMove.AddListener(HandleMove);
        input.OnRotate.AddListener(HandleRotate);
        input.OnJump.AddListener(HandleJump);
    }

    void OnDisable()
    {
        input.OnMove.RemoveListener(HandleMove);
        input.OnRotate.RemoveListener(HandleRotate);
        input.OnJump.RemoveListener(HandleJump);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + currentVelocity * Time.fixedDeltaTime);
    }

    void HandleMove(Vector2 direction)
    {
        currentVelocity = (transform.forward * direction.y + transform.right * direction.x).normalized * moveSpeed;
    }

    void HandleRotate(float mouseX)
    {
        yaw += mouseX * rotationSpeed;
        transform.rotation = Quaternion.Euler(0f, yaw, 0f);
    }

    void HandleJump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = true;
    }
}
