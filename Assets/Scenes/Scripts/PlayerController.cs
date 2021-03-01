using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 15.0f;
    private float horizontalInput;
    private float verticalInput;
    
    private Rigidbody rb;

    private bool jumpInputed;
    private bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
            jumpInputed = true;
    }

    private void FixedUpdate()
    {
        
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
        transform.Translate(Vector3.left * Time.deltaTime * speed * horizontalInput);

        if (jumpInputed && isGrounded)
        {
            rb.AddForce(Vector3.up * 7, ForceMode.VelocityChange);
            jumpInputed = false;
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isGrounded = true;
        }   
    }
}
