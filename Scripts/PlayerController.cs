using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 5f;
    public float rotationSpeed = 120f;

    [Header("Jumping")]
    public float jumpForce = 0.1f;
    public float groundCheckDistance = 1.1f;

    [Header("Shooting")]
    public GameObject projectilePrefab;
    public float shootForce = 20f;
    public float shootCooldown = 0.2f;

    private Rigidbody rb;
    private float lastShootTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("try shoot");
            if (CanShoot())
            {
                Debug.Log(" shoot");
                
                Shoot();
                
            }
            
        }
    }

    private void FixedUpdate()
    {
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = transform.forward * moveVertical * speed
        * Time.fixedDeltaTime;

        rb.MovePosition(rb.position + movement);

        float turn = Input.GetAxis("Horizontal") * rotationSpeed
         * Time.fixedDeltaTime;

        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
        
        // Check for shooting input
       
       
    }
    
    private bool IsOnGround()
    {
        // Shoots a ray downward from the center of the player
        return Physics.Raycast(transform.position, Vector3.down, groundCheckDistance);
    }

    private bool CanShoot()
    {
        return projectilePrefab != null && Time.time >= lastShootTime + shootCooldown;
    }

    private void Shoot()
    {
        if (projectilePrefab == null)
        {
            Debug.LogWarning("No projectile prefab assigned!");
            return;
        }

        // Instantiate the projectile at the player's center position
        GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
        
     

        // Update last shoot time for cooldown
        lastShootTime = Time.time;
    }
}