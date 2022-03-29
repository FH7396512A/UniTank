using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers s_instance; // 유일성 보장
    static Managers Instance { get { Init(); return s_instance; } }

    InputManager _input = new InputManager(); // 객체생성을 함으로서 InputManager를 사용할수 있음

    public static InputManager Input { get { return Instance._input; } }

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    void Update()
    {
        _input.OnUpdate();
    }

    static void Init()
    {
        if (s_instance == null)
        {
            GameObject go = GameObject.Find("@Managers"); //문자열과 일치하는 인수를 찾아서 리턴함
            if (go == null)
            {
                go = new GameObject { name = "@Managers" }; //@Managers 오브젝트가 없으면 생성하고 Managers.cs 컴포넌트를 넣어줌
                go.AddComponent<Managers>();
            }
            DontDestroyOnLoad(go);                          //오브젝트가 안사라지고 유지하게해줌
            s_instance = go.GetComponent<Managers>();
        }
    }
}

