using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class close_menu : MonoBehaviour
{
    public void OnMouseClick()
    {
        GameObject target = GameObject.FindGameObjectWithTag("SubMenu");
        Destroy(target);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Game_Manager.instance.menu_on = false;
    }
}
