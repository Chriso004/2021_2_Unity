using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    public static Game_Manager instance;
    public int size;
    public float stamina;
    public bool menu_on = false;
    public int set_time;

    public enum TIME
    {
        DAY = 1,
        AFTERNOON,
        NIGHT
    };

    public enum DIFFCULT
    {
        standard = 21,
        large = 35,
        expanded = 51
    };
    
    //삭제되면 안되는 오브젝트이므로 DontDestroyOnLoad 실행
    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(instance);
    }

    //esc누를시 메뉴 생성
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().name == "main_scene")
        {
            show_esc_menu();
        }
    }

    void show_esc_menu()
    {
        if(!menu_on)
        {
            GameObject menu = Resources.Load<GameObject>("Prefabs/Buttons/Escape_menu");
            Instantiate(menu);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            menu_on = true;
        }
    }

    //게임 시작
    public void game_start()
    {
        SceneManager.LoadScene("main_scene");
        set_time = (int)TIME.DAY;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
