using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_ctrl : MonoBehaviour
{
    private GameObject target;
    private float move_speed = 2.0f;  
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * Time.deltaTime;

        Vector3 Position = transform.position;
        transform.position += new Vector3(horizontal * move_speed, 0, vertical * move_speed);
    }
}
