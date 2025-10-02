using UnityEngine;
using UnityEngine.SceneManagement;

public class EneemyRandomMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float changeDirectionTime = 2f;

    public BoxCollider boundaryBox; //
    public float boundaryMargin = 0.5f; // 

    private Vector3 moveDirection;
    private float directionTimer;
    private bool correctingCourse = false;//

    void Start()
    {
        PickRandomDirection();
    }

    void Update()
    {
        transform.Translate(moveDirection * moveSpeed
        * Time.deltaTime, Space.World);

        if (!IsInsideBounds(transform.position))
        {
            if (!correctingCourse) // only trigger once
            {
                correctingCourse = true;
                PickRandomInsideDirection();
            }
        }
        else
        {
            correctingCourse = false;
        }

        directionTimer -= Time.deltaTime;
        if (directionTimer <= 0f && !correctingCourse)
        {
            PickRandomDirection();
        }
    }

    void PickRandomDirection()
    {
        float randomX = Random.Range(-1f, 1f);
        float randomZ = Random.Range(-1f, 1f);
        moveDirection = new Vector3(randomX, 0f, randomZ).normalized;

        if (moveDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveDirection);
        }

        directionTimer = changeDirectionTime;
    }

    void PickRandomInsideDirection()
    {
        Vector3 min = boundaryBox.bounds.min + Vector3.one *
        boundaryMargin;

        Vector3 max = boundaryBox.bounds.max - Vector3.one *
        boundaryMargin;

        Vector3 randomPointInside = new Vector3(
            Random.Range(min.x, max.x),
            transform.position.y,
            Random.Range(min.z, max.z)
        );

        moveDirection = (randomPointInside - transform.position).normalized;
        transform.rotation = Quaternion.LookRotation(moveDirection);
        directionTimer = changeDirectionTime;
    }

    bool IsInsideBounds(Vector3 position)
    {
        Vector3 min = boundaryBox.bounds.min +
        new Vector3(boundaryMargin, 0f, boundaryMargin);

        Vector3 max = boundaryBox.bounds.max -
        new Vector3(boundaryMargin, 0f, boundaryMargin);

        return position.x >= min.x && position.x <= max.x &&
               position.z >= min.z && position.z <= max.z;
    }

    void OnCollisionEnter(Collision collision)
    {

        PickRandomDirection();
        
        
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            FindAnyObjectByType<GameManager>().GameOver();
        }
    }
}
