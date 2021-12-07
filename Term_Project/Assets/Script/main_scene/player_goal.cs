using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class player_goal : MonoBehaviour
{
    //미로 탈출 스크립트
    private float count = 5.0f;
    private Text countdown;
    private GameObject count_ui;
    private bool is_goal = false;
    private float wait_time = 0.0f;

    //5초 뒤 메인메뉴로 이동
    void Update()
    {
        if(is_goal)
        {
            if(count - wait_time <= 0)
            {
                SceneManager.LoadScene("menu_scene");
                is_goal = false;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            wait_time += Time.deltaTime;
            countdown.text = Mathf.Round(count - wait_time).ToString();
        }
    }
    
    //골인지점 도착 판단 함수
    public void OnTriggerEnter(Collider other)
    {
        GameObject target = GameObject.FindGameObjectWithTag("Player");
        if(other.gameObject == target)
        {
            count_ui = Resources.Load<GameObject>("Prefabs/UI/FinishGame");
            Instantiate(count_ui);
            countdown = GameObject.Find("Count").GetComponent<Text>();
            is_goal = true;
        }
    }
}
