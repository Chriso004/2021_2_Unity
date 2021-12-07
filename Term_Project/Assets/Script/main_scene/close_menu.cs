using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class close_menu : MonoBehaviour
{
    //아니오 버튼 클릭시 메뉴 닫기
    public void OnMouseClick()
    {
        GameObject target = GameObject.FindGameObjectWithTag("SubMenu");
        Destroy(target);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Game_Manager.instance.menu_on = false;
    }
}
