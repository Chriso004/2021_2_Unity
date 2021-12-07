using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class large_text : MonoBehaviour
{
    //지침 난이도 설정
    private GameObject text_box;
    private Text explain_text;

    public void Start()
    {
        text_box = GameObject.Find("explain_text");
        explain_text = text_box.GetComponent<Text>();
    }
    public void OnMouseOver()
    {
        explain_text.text = "길을 찾는데에 시간이 더 걸립니다.";
    }

    public void OnMouseExit()
    {
        explain_text.text = "";
    }

    public void OnMouseClick()
    {
        Game_Manager m = GameObject.Find("GameManager").GetComponent<Game_Manager>();
        m.size = (int)Game_Manager.DIFFCULT.large;
        m.game_start();
    }
}
