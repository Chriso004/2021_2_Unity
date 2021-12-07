using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light_ctrl : MonoBehaviour
{

    //낮, 저녁, 밤 조명 설정
    GameObject light1;
    GameObject light2;
    const float DAY_FOG = 0.028f;
    const float AFTERNOON_FOG = 0.035f;
    const float NIGHT_FOG = 0.07f;

    //초기 조명 설정    
    void Start()
    {
        light1 = GameObject.Find("Sun1");
        light2 = GameObject.Find("Sun2");
    }

    //시간에 따라 조명 각도 설정
    public void set_sun()
    {
        int temp = Game_Manager.instance.set_time;
        
        //낮 -> 저녁
        if(temp == (int)Game_Manager.TIME.DAY)
        {
            Game_Manager.instance.set_time = (int)Game_Manager.TIME.AFTERNOON;
            light1.transform.eulerAngles = new Vector3(-5.0f, 30.0f, 0);
            light2.transform.eulerAngles = new Vector3(25.0f, 90.0f, 0);
            RenderSettings.fogDensity = AFTERNOON_FOG;
        }

        //저녁 -> 밤
        else if(temp == (int)Game_Manager.TIME.AFTERNOON)
        {
            Game_Manager.instance.set_time = (int)Game_Manager.TIME.NIGHT;
            light1.transform.eulerAngles = new Vector3(270.0f, -30.0f, 0);
            light2.transform.eulerAngles = new Vector3(-50.0f, 90.0f, 0);
            RenderSettings.fogDensity = NIGHT_FOG;
        }

        //밤 -> 낮
        else
        {
            Game_Manager.instance.set_time = (int)Game_Manager.TIME.DAY;
            light1.transform.eulerAngles = new Vector3(50.0f, -30.0f, 0);
            light2.transform.eulerAngles = new Vector3(50.0f, 90.0f, 0);
            RenderSettings.fogDensity = DAY_FOG;
        }
    }
}
