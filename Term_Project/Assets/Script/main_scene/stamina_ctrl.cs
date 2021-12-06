using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stamina_ctrl : MonoBehaviour
{
    private ProgressBar pb;
    private GameObject UI;
    private Animator animator;
    private float distance;
    private float stamina_reduce = 10f;
    private Image screen;
    private float fade_speed = 0.1f;
    void Start()
    {
        setObject();
        distance = 0.0f;
        Game_Manager.instance.stamina = 0.0f;
    }

    void setObject()
    {
        UI = Resources.Load<GameObject>("Prefabs/UI/Stamina");
        Instantiate(UI);
        pb = GameObject.Find("StaminaBar").GetComponent<ProgressBar>();
        animator = GetComponent<Animator>();
    }

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

        if(Input.GetKeyDown(KeyCode.R) && Game_Manager.instance.stamina <= 0.0f)
        {
            Game_Manager.instance.stamina = 100.0f;
            animator.speed = 1;
        }
    }
}
