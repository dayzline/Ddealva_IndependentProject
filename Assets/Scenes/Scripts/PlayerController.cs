using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float walk = 10.0f;
    private float sprint = 20.0f;
    private float horizontalInput;
    private float verticalInput;
    private float mouseXInput;
    private float mouseYInput;
    
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
        mouseXInput = Input.GetAxis("Mouse X");
        //mouseYInput = Input.GetAxis("Mouse Y");

        if (Input.GetKeyDown(KeyCode.Space))
            jumpInputed = true;
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        { 
            transform.Translate(Vector3.forward * Time.deltaTime * sprint * verticalInput); 
        }

        else 
        {
            transform.Translate(Vector3.forward * Time.deltaTime * walk * verticalInput);
        }
        
        transform.Translate(Vector3.right * Time.deltaTime * walk * horizontalInput);
        //transform.Rotate(Vector3.left * mouseYInput * speed);
        transform.Rotate(Vector3.up * mouseXInput * walk);


        if (jumpInputed && isGrounded)
        {
            rb.AddForce(Vector3.up * 8, ForceMode.Impulse);
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
