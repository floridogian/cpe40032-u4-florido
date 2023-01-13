using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Private Variables
    private Rigidbody playerRb; // Variable for Rigidbody of player
    private float speed = 5.0f; // Speed of the player
    private GameObject focalPoint; // Variable for focal point used in the main camera
    private float powerUpStrength = 15.0f; // Force strenth of the player once it has a powerup

    // Public Variables
    public bool hasPowerup = false; // Boolean variable for powerup
    public GameObject powerupIndicator; // Variable for powerup indicator

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>(); // Initialize the variable by getting the player's Rigidody component
        focalPoint = GameObject.Find("Focal Point"); // Iniitialize the variable by finding the focal point
    }

    // Update is called once per frame
    void Update()
    {
        // Moves the player using the up and down arrow keys or W and S and its focal point rotation
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);

        // Indicators that the player has powerup
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Once the player acquired the powerup, the codes below will be executed
        if(other.CompareTag("Powerup"))
        {
            hasPowerup = true; // Set the boolean variable hasPowerup to true
            Destroy(other.gameObject); // Destroy the powerup object
            StartCoroutine(PowerupCountdownRoutine()); // Starts the countdown of the time limit of powerup
            powerupIndicator.gameObject.SetActive(true); // Powerup indicator will be activated on the player
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7); // Time limit of the powerup

        // Once the countdown is over, hasPowerup and powerupIndicator will be set to false
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Once the player acquire the powerup, its force strength against the enemy will be stronger
        if(collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;

            enemyRigidbody.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
            Debug.Log("Collided with " + collision.gameObject.name + " with the powerup set to " + hasPowerup);
        }
    }
}
