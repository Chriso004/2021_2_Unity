using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_ctrl : MonoBehaviour
{ 
    private float turnSpeed = 50.0f; // 마우스 회전 속도    
    private float rotationX = 0.0f;
    private float rotationY = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        rotationX = transform.eulerAngles.x;
        rotationY = transform.eulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");

        rotationX += x * turnSpeed * Time.deltaTime;
        rotationY += y * turnSpeed * Time.deltaTime;

        rotationY = Mathf.Clamp(rotationY, -45, 80);
        transform.eulerAngles = new Vector3(-rotationY, rotationX, 0.0f);
    }
}
