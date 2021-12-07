using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stamina_ctrl : MonoBehaviour
{
    //스태미너 조절 스크립트
    private ProgressBar pb;
    private GameObject UI;
    private Animator animator;
    private float distance;
    private float stamina_reduce = 0.1f;
    
    void Start()
    {
        setObject();
        distance = 0.0f;
        Game_Manager.instance.stamina = 100.0f;
    }

    //게임 시작시 UI생성
    void setObject()
    {
        UI = Resources.Load<GameObject>("Prefabs/UI/Stamina");
        Instantiate(UI);
        pb = GameObject.Find("StaminaBar").GetComponent<ProgressBar>();
        animator = GetComponent<Animator>();
    }

    //이동 거리에 따라 스태미너 감소
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        distance = Mathf.Abs(h * Time.deltaTime * stamina_reduce);
        distance = Mathf.Abs(v * Time.deltaTime * stamina_reduce);

        Game_Manager.instance.stamina -= distance;

        if(Game_Manager.instance.stamina <= 0.0f)
        {
            pb.BarValue = 0.0f;
            animator.speed = 0;
        }

        pb.BarValue = Game_Manager.instance.stamina;

        //스태미너가 0이 된 뒤 R키를 누르면 스태미너 회복 후 시간 변화
        if(Input.GetKeyDown(KeyCode.R) && Game_Manager.instance.stamina <= 0.0f)
        {
            Game_Manager.instance.stamina = 100.0f;
            animator.speed = 1;
            GameObject.Find("LightManager").GetComponent<light_ctrl>().set_sun();
        }
    }
}
