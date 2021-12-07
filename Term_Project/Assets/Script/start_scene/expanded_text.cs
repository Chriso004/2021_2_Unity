using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class expanded_text : MonoBehaviour
{
    //확장 난이도 세팅
    private GameObject text_box;
    private Text explain_text;
    public void Start()
    {
        text_box = GameObject.Find("explain_text");
        explain_text = text_box.GetComponent<Text>();
    }
    public void OnMouseOver()
    {
        explain_text.text = "계속해서 헤메게 될 것 입니다.";
    }

    public void OnMouseExit()
    {
        explain_text.text = "";
    }

    //난이도 설정 후 게임 시작
    public void OnMouseClick()
    {
        Game_Manager m = GameObject.Find("GameManager").GetComponent<Game_Manager>();
        m.size = (int)Game_Manager.DIFFCULT.expanded;
        m.game_start();
    }
}
