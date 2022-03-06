using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    float _speed = 2.0f;    //탱크 이동속도
    float rotateSpeed = 50f;//포신 각속도
    int isRight;            //방향 변수 right = 1, left = -1
    float _angle;

    

    private float _hp, _maxhp;
    private float _move, _maxmove;
    private float _maxangleIndi;
    [SerializeField]
    public GameObject _PlayerInfo;
    public Slider _HpBar;
    public Slider _MoveBar;
    public Slider _AngleIndicate;
    public GameObject canvas;
    public GameObject BTank_C_cannon;
    RectTransform HPBar_t;
    RectTransform MVBar_t;
    RectTransform NameUI_t;
    Slider HPBar_I;
    Slider MVBar_I;
    Slider AngleIndicate_I;
    public float WheelRotateSpeed = 100f;
    public GameObject CameraObject;
    public GameObject UI;
    


    LineRenderer LR;
    

    public GameObject _Bullet;
    int delay = 0;
    float timer = 0;

    float radA, radB;
    

    void Start()
    {
        Managers.Input.KeyAction -= OnKeyboard;
        Managers.Input.KeyAction += OnKeyboard;
        isRight = 1;
        transform.localScale = new Vector3(0.5f, 0.5f, 1);
        _angle = 0;

        _maxmove = 100;
        _move = 100;
        _maxhp = 100;
        _hp = 100;
        _maxangleIndi = 100;

        
        


        Slider HPB = Instantiate(_HpBar, canvas.transform);
        HPBar_t = HPB.GetComponent<RectTransform>();
        HPBar_I = HPB;
        Slider MVB = Instantiate(_MoveBar, canvas.transform);
        MVBar_t = MVB.GetComponent<RectTransform>();
        MVBar_I = MVB;
        NameUI_t = Instantiate(_PlayerInfo, canvas.transform).GetComponent<RectTransform>();
        Slider AIndi = Instantiate(_AngleIndicate, canvas.transform);
        AngleIndicate_I = AIndi;
        LR = GetComponent<LineRenderer>();
        GameObject UII = Instantiate(UI, canvas.transform);
        

    }

    void Update()
    {
        Vector3 HPBarPos = Camera.main.WorldToScreenPoint(new Vector3(transform.position.x, transform.position.y + 1.95f, 0));
        HPBar_t.position = HPBarPos;
        Vector3 MVBarPos = Camera.main.WorldToScreenPoint(new Vector3(transform.position.x, transform.position.y + 1.8f, 0));
        MVBar_t.position = MVBarPos;
        Vector3 NameUIPos = Camera.main.WorldToScreenPoint(new Vector3(transform.position.x, transform.position.y - 0.8f, 0));
        NameUI_t.position = NameUIPos;
        HPBar_I.value = _hp / _maxhp;
        MVBar_I.value = _move / _maxmove;

        Vector3 a = transform.GetChild(0).GetChild(0).GetComponent<Transform>().position;
        Vector3 b = transform.GetChild(2).GetComponent<Transform>().position;
        //Vector3 a = transform.GetChild(0).GetChild(0).GetComponent<Transform>().localPosition;
        //Vector3 b = transform.GetChild(2).GetComponent<Transform>().localPosition;
        


        if (isRight == 1)
        {
            radA = Mathf.Atan2(a.y - b.y, a.x - b.x);
            radB = radA * 180 / Mathf.PI;
            AngleIndicate_I.value = radB * 1.111f / _maxangleIndi;           
        }
        else
        {
            radA = Mathf.Atan2(a.y - b.y, -(a.x - b.x));
            radB = radA * 180 / Mathf.PI;
            AngleIndicate_I.value = radB * 1.111f / _maxangleIndi;
        }
            
        LR.SetPosition(0, transform.GetChild(0).GetChild(1).GetComponent<Transform>().position); 
        LR.SetPosition(1, transform.GetChild(0).GetChild(2).GetComponent<Transform>().position);


        if (timer <= 120) timer += 1;
        if (timer > 120) delay = 0;
    }

    void OnKeyboard()
    {
        if (CameraObject.GetComponent<MainCamCtrl>().checkZoomOut == false)
        {
            //upArrow 누를 때 포신 기울기 조절 (수평~수직 범위)
            if (Input.GetKey(KeyCode.UpArrow) && _angle < 70f)
            {
                _angle += rotateSpeed * Time.deltaTime;
                transform.GetChild(0).GetComponent<Transform>().RotateAround(
                    transform.GetChild(2).GetComponent<Transform>().position, Vector3.forward, rotateSpeed * Time.deltaTime * isRight);
            }
            //downArrow 누를 때 포신 기울기 조절 (수평~수직 범위)
            if (Input.GetKey(KeyCode.DownArrow) && _angle > -20f)
            {
                _angle -= rotateSpeed * Time.deltaTime;
                transform.GetChild(0).GetComponent<Transform>().RotateAround(
                    transform.GetChild(2).GetComponent<Transform>().position, Vector3.back, rotateSpeed * Time.deltaTime * isRight);
            }
            //rightArrow 누를 때 오른쪽 이동 / sprite 복구
            if (Input.GetKey(KeyCode.RightArrow))
            {
                isRight = 1;
                //_move -= 1;
                transform.localScale = new Vector3(0.5f, 0.5f, 1);
                if (_move > 0) transform.position += Vector3.right * Time.deltaTime * _speed;
                transform.GetChild(4).Rotate(0, 0, -Time.deltaTime * WheelRotateSpeed, Space.Self);
                transform.GetChild(5).Rotate(0, 0, -Time.deltaTime * WheelRotateSpeed, Space.Self);
            }
            //leftArrow 누를 때 왼쪽 이동 / sprite 반전
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                isRight = -1;
                //_move -= 1;
                transform.localScale = new Vector3(-0.5f, 0.5f, 1);
                if (_move > 0) transform.position += Vector3.left * Time.deltaTime * _speed;
                transform.GetChild(4).Rotate(0, 0, -Time.deltaTime * WheelRotateSpeed, Space.Self);
                transform.GetChild(5).Rotate(0, 0, -Time.deltaTime * WheelRotateSpeed, Space.Self);
            }
            if (Input.GetKey(KeyCode.Space))
            {
                if (delay == 0)
                {
                    GameObject Bullet_Ins = Instantiate(_Bullet, transform.GetChild(0).GetChild(0));
                    Vector3 a = transform.GetChild(0).GetChild(0).GetComponent<Transform>().position;
                    Vector3 b = transform.GetChild(2).GetComponent<Transform>().position;
                    Bullet_Ins.GetComponent<BulletControl>()._direction = a - b;
                    timer = 0;
                    delay = 1;
                }
            }
        }
        else
            return;
    }
    
}
