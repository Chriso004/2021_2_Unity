using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    public static Game_Manager instance;
    public int size;
    public enum DIFFCULT
    {
        standard = 21,
        large = 35,
        expanded = 51
    };
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(instance);
    }
}
