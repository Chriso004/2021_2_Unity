using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footstep_ctrl : MonoBehaviour
{
    public AudioSource src;
    private bool is_move = false;
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if((h == 0 && v == 0) || Game_Manager.instance.stamina <= 0)
            is_move = false;

        else
            is_move = true;

        if(is_move)
        {
            if(!src.isPlaying)
                src.Play();
        }

        else
            src.Stop();
    }
}
