using UnityEngine;

public class Collectible : MonoBehaviour
{
    private float rotationSpeed = 1f;
    public GameObject particle;
    private bool collected; //
    private AudioSource audioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        collected = false;// 
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotationSpeed, rotationSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player") && !collected)
        {
            GetComponent<Renderer>().enabled = false;

            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
                {
                    player.speed *= 5f;
                }
            //
            collected = true;
            //
          
          
            audioSource.Play();

            Instantiate(particle, transform.position, transform.rotation);

            Destroy(gameObject, audioSource.clip.length);


        }
    }
}
