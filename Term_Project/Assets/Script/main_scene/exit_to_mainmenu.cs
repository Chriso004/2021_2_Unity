using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class exit_to_mainmenu : MonoBehaviour
{
    //예 누를시 메인 메뉴로 이동
    public void OnMouseClick()
    {
        SceneManager.LoadScene("menu_scene");
        Destroy(GameObject.Find("Escape_menu"));
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Game_Manager.instance.menu_on = false;
    }
}
