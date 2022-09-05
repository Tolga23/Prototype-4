using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 7.0f;
    private float powerupStrength = 15.0f;

    private Rigidbody playerRb;
    private GameObject focalPoint;
    public GameObject powerUpIndicator;
    public bool hasPowerup = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        

        playerRb.AddForce(focalPoint.transform.forward * speed * verticalInput);
        
        powerUpIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject); 
            StartCoroutine(PowerUpCountTimeRoutine()); 
            powerUpIndicator.gameObject.SetActive(true); 
        }
    }

    IEnumerator PowerUpCountTimeRoutine()
    {
        yield return new WaitForSeconds(5); 
        hasPowerup = false;
        powerUpIndicator.gameObject.SetActive(false); 
    }

    private void OnCollisionEnter(Collision collision)
    {
        // PowerUp effect
        if(collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();

            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position; 

            enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
        }
    }
}
