using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start_ctrl : MonoBehaviour
{
    private GameObject menu;
    public void OnClickStart()
    {
        menu = GameObject.Find("main_menu");
        Destroy(menu);
        menu = Resources.Load<GameObject>("Prefabs/Buttons/diffcult_select");
        Instantiate(menu);
    }
}
