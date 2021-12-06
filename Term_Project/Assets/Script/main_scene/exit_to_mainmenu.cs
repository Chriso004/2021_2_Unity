using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class exit_to_mainmenu : MonoBehaviour
{
    public void OnMouseClick()
    {
        SceneManager.LoadScene("menu_scene");
        Destroy(GameObject.Find("Escape_menu"));
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Game_Manager.instance.menu_on = false;
    }
}
