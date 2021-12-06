using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_goal : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        GameObject target = GameObject.FindGameObjectWithTag("Player");
        Debug.Log(target);
        Debug.Log(other.gameObject);
        if(other.gameObject == target)
        {
            Debug.Log("goal");
        }
    }
}
