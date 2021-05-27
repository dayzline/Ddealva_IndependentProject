using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewChanger : MonoBehaviour
{
    public int speed;
    void Update()
    {
        float mouseXImput = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up, mouseXImput * speed * Time.deltaTime);
    }
}
