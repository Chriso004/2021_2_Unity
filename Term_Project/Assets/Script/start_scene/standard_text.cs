using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class standard_text : MonoBehaviour
{
    private GameObject text_box;
    private Text explain_text;

    public void Start()
    {
        text_box = GameObject.Find("explain_text");
        explain_text = text_box.GetComponent<Text>();
    }
    public void OnMouseOver()
    {
        explain_text.text = "표준크기의 지도입니다.";
    }

    public void OnMouseExit()
    {
        explain_text.text = "";
    }

    public void OnMouseClick()
    {
        Game_Manager m = GameObject.Find("GameManager").GetComponent<Game_Manager>();
        m.size = (int)Game_Manager.DIFFCULT.standard;
        m.game_start();
    }
}
