using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start_menu_camera_ctrl : MonoBehaviour
{
    private float move_speed = 1.0f;
    void LateUpdate()
    {
        Vector3 target_point = new Vector3(transform.position.x, 1.5f, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, target_point, move_speed * Time.deltaTime);
    }
}
