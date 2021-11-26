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

    private GameObject _PlayerInfo;
    private float _hp, _maxhp;
    private float _move, _maxmove;
    public Slider _HpBar;
    public Slider _MoveBar;

    public GameObject _Bullet;
    int delay = 0;
    float timer = 0;
    void Start()
    {
        Managers.Input.KeyAction -= OnKeyboard;
        Managers.Input.KeyAction += OnKeyboard;
        isRight = 1;
        transform.localScale = new Vector3(0.5f, 0.5f, 1);
        _angle = 0;

        _PlayerInfo = GameObject.Find("Canvas/PlayerInfo");
        _maxmove = 100;
        _move = 100;
        _maxhp = 100;
        _hp = 100;
    }

    void Update()
    {
        _PlayerInfo.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, 0.7f, 0));
        _HpBar.value = _hp / _maxhp;
        _MoveBar.value = _move / _maxmove;

        timer += 1;
        if (timer > 120) delay = 0;
    }

    void OnKeyboard()
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
            _move -= 1;
            transform.localScale = new Vector3(0.5f, 0.5f, 1);
            if (_move > 0) transform.position += Vector3.right * Time.deltaTime * _speed;
        }
        //leftArrow 누를 때 왼쪽 이동 / sprite 반전
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            isRight = -1;
            _move -= 1;
            transform.localScale = new Vector3(-0.5f, 0.5f, 1);
            if (_move > 0) transform.position += Vector3.left * Time.deltaTime * _speed;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            if (delay == 0)
            {
                GameObject Bullet_Ins = Instantiate(_Bullet, transform.GetChild(0).GetChild(0));
                Bullet_Ins.GetComponent<BulletControl>()._direction
                    = transform.GetChild(0).GetChild(0).GetComponent<Transform>().position
                    - transform.GetChild(2).GetComponent<Transform>().position;
                if (isRight == -1) Bullet_Ins.GetComponent<BulletControl>()._direction.x
                        = -Bullet_Ins.GetComponent<BulletControl>()._direction.x;
                timer = 0;
                delay = 1;
            }
        }
    }
}
