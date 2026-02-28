using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 100f;
    public float acceleration = 100f;

    [Header("Jump Settings")]
    public float jumpForce = 300f;
    public int maxJumpCount = 2;
    private int jumpCount = 0;

    [Header("Dash Settings")]
    public float dashForce = 20f;
    public float dashDuration = 0.2f;
    public float dashCooldown = 1.0f;
    private bool isDashing = false;
    private float dashTimer = 0f;
    private float dashCooldownTimer = 0f;
    private Vector3 lastMoveDirection = Vector3.zero;

    private Rigidbody rb;
    private Transform cam;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (Camera.main != null)
        {
            cam = Camera.main.transform;
        }
        else
        {
            Debug.LogError("Main Camera not found. Please tag your camera as 'MainCamera'.");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && dashCooldownTimer <= 0f && lastMoveDirection != Vector3.zero)
        {
            isDashing = true;
            dashTimer = dashDuration;
            dashCooldownTimer = dashCooldown;
        }

        if (dashCooldownTimer > 0f)
        {
            dashCooldownTimer -= Time.deltaTime;
        }
        if (isDashing)
        {
            dashTimer -= Time.deltaTime;
            if (dashTimer <= 0f)
            {
                isDashing = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumpCount)
        {
            rb.AddForce(Vector3.up * jumpForce);
            jumpCount++;
        }
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }


    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 inputDirection = new Vector3(horizontal, 0f, vertical);
        if (inputDirection.magnitude > 1f)
            inputDirection.Normalize();

        if (cam != null)
        {
            Vector3 camForward = cam.forward;
            camForward.y = 0f;
            camForward.Normalize();
            Vector3 camRight = cam.right;
            camRight.y = 0f;
            camRight.Normalize();

            Vector3 moveDirection = (camForward * vertical + camRight * horizontal).normalized;

            if (moveDirection != Vector3.zero)
                lastMoveDirection = moveDirection;
            if (isDashing)
            {
                Vector3 dashVelocity = lastMoveDirection * dashForce;
                dashVelocity.y = rb.linearVelocity.y;
                rb.linearVelocity = dashVelocity;
            }
            else
            {
                Vector3 targetVelocity = moveDirection * speed;
                targetVelocity.y = rb.linearVelocity.y;
                rb.linearVelocity = Vector3.Lerp(rb.linearVelocity, targetVelocity, acceleration * Time.fixedDeltaTime);
            }
        }
        }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0;
        }
    }
}
