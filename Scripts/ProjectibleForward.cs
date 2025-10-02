using UnityEngine;
using UnityEngine.SceneManagement;

public class ProjectibleForward : MonoBehaviour
{
    [Header("Bullet Settings")]
    public float speed = 20f;
    public float lifetime = 40f;
    public static int destroyedEnemies = 0;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        // Move the bullet forward
        rb.linearVelocity = transform.forward * speed;
        
        // Destroy the bullet after lifetime seconds to prevent memory leaks
        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            Destroy(other.gameObject);

            Destroy(gameObject);
            destroyedEnemies++;
           
                FindAnyObjectByType<GameManager>().CollectedItem();
            
        }
    }

    
}
