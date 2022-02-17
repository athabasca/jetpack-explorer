using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] AudioClip mainEngine;
    [SerializeField] float thrustSpeed = 500f;
    [SerializeField] float rotationThrust = 100f;

    Rigidbody rb;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust() {
        
        if(Input.GetKey(KeyCode.Space)) {
            rb.AddRelativeForce(Vector3.up * thrustSpeed * Time.deltaTime);
            
            if(!audioSource.isPlaying) {
                audioSource.PlayOneShot(mainEngine);
            }
        }
        else {
            audioSource.Stop();
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationThrust);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotationThrust);
        }
    }

    void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; // Freeze physics-based rotation
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false; // Done manually rotating
    }
}
