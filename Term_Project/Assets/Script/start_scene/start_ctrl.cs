using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start_ctrl : MonoBehaviour
{
    //난이도 설정 메뉴 관련 스크립트
    private GameObject menu;

    public void OnClickStart()
    {
        menu = GameObject.Find("main_menu");
        Destroy(menu);
        menu = Resources.Load<GameObject>("Prefabs/Buttons/diffcult_select");
        Instantiate(menu);
    }
}
