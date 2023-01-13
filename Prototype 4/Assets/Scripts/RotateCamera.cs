using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    // Private Variable
    private float rotationSpeed = 100.0f; // Speed of the camera rotation

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Rotates the camera using the left and right arrow key or A and D
        float horizontalInput = Input.GetAxis("Horizontal"); 
        transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);
    }
}