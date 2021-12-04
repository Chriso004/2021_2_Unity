using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class expanded_text : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject text_box;
    private Text explain_text;
    // Start is called before the first frame update
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

    public void OnMouseClick()
    {
        Game_Manager.instance.size = (int)Game_Manager.DIFFCULT.expanded;
        SceneManager.LoadScene("main_scene");
    }
}
