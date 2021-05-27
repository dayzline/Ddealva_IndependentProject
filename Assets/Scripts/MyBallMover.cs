using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBallMover : MonoBehaviour
{
    Rigidbody rbPlayer;
    GameObject focalPoint;

    public float speed;
    public float superSpeed;

    void Start()
    {
        rbPlayer = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        float sideInput = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            rbPlayer.AddForce(focalPoint.transform.forward * forwardInput * superSpeed * Time.deltaTime, ForceMode.Impulse);
            rbPlayer.AddForce(focalPoint.transform.right * sideInput * superSpeed * Time.deltaTime, ForceMode.Impulse);
        }

        else
        {
            rbPlayer.AddForce(focalPoint.transform.forward * forwardInput * speed * Time.deltaTime, ForceMode.Impulse);
            rbPlayer.AddForce(focalPoint.transform.right * sideInput * speed * Time.deltaTime, ForceMode.Impulse);
        }
    }
}
