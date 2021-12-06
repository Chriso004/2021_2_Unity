using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main_camera_ctrl : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject target;
    private float rotate_speed = 70.0f;
    private float rx;
    private float ry;
    void Start()
    {   
        target = GameObject.FindGameObjectWithTag("MainCamera");
        rx = 0.0f;
        ry = 0.0f;
    }
    void LateUpdate()
    {
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");

        rx += Time.deltaTime * y * rotate_speed;
        ry += Time.deltaTime * x * rotate_speed;

        rx = Mathf.Clamp(rx, -80, 80);
        transform.eulerAngles = new Vector3(-rx, ry, 0);
    }
}
