using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_opening : MonoBehaviour
{
    private GameObject target;
    private float move_speed = 1.0f;
    void Start()
    {
        target = GameObject.Find("Camera");
        camera_set();
    }

    void LateUpdate()
    {
        Vector3 point = new Vector3(5.0f, 5, 5.0f);
        transform.position = Vector3.Lerp(transform.position, point, move_speed * Time.deltaTime);
        if(transform.position.x < point.x + 1.0f)
        {
            player_spawn();
            Destroy(target);
            gameObject.GetComponent<camera_opening>().enabled = false;
        }
    }

    public void camera_set()
    {
        int size = Game_Manager.instance.size;
        target.transform.position = new Vector3(((size - 2) * 10.0f), 5.0f, ((size - 2) * 10.0f));
        target.transform.eulerAngles = new Vector3(0, 45.0f, 0);
    }

    public void player_spawn()
    {
        GameObject player;
        player = Resources.Load<GameObject>("Prefabs/Stage/Player");
        Instantiate(player);
        player.transform.position = new Vector3(10.0f, 1.0f, 10.0f);
    }
}
