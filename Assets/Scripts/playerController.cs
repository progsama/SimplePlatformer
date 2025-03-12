using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 50f;
    public float acceleration = 50f;

    [Header("Jump Settings")]
    public float jumpForce = 300f;
    public int maxJumpCount = 2;
    private int jumpCount = 0;

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
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumpCount)
        {
            rb.AddForce(Vector3.up * jumpForce);
            jumpCount++;
        }
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
            Vector3 targetVelocity = moveDirection * speed;

            targetVelocity.y = rb.linearVelocity.y;

            rb.linearVelocity = Vector3.Lerp(rb.linearVelocity, targetVelocity, acceleration * Time.fixedDeltaTime);
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
