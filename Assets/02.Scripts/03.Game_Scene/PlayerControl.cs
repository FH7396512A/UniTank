using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    float _speed = 2.0f;    //탱크 이동속도
    float rotateSpeed = 50f;//포신 각속도
    int isRight;            //방향 변수 right = 1, left = -1
    float _angle;

    void Start()
    {
        Managers.Input.KeyAction -= OnKeyboard;
        Managers.Input.KeyAction += OnKeyboard;
        isRight = 1;
        transform.localScale = new Vector3(0.5f, 0.5f, 1);
        _angle = 0;
    }

    void Update()
    {

    }

    void OnKeyboard()
    {
        //upArrow 누를 때 포신 기울기 조절 (수평~수직 범위)
        if (Input.GetKey(KeyCode.UpArrow) && _angle < 70f)
        {
            _angle += rotateSpeed * Time.deltaTime;
            Debug.Log(_angle);
            transform.GetChild(0).GetComponent<Transform>().RotateAround(
                transform.GetChild(2).GetComponent<Transform>().position, Vector3.forward, rotateSpeed * Time.deltaTime * isRight);
        }
        //downArrow 누를 때 포신 기울기 조절 (수평~수직 범위)
        if (Input.GetKey(KeyCode.DownArrow) && _angle > -20f)
        {
            _angle -= rotateSpeed * Time.deltaTime;
            Debug.Log(_angle);
            transform.GetChild(0).GetComponent<Transform>().RotateAround(
                transform.GetChild(2).GetComponent<Transform>().position, Vector3.back, rotateSpeed * Time.deltaTime * isRight);
        }
        //rightArrow 누를 때 오른쪽 이동 / sprite 복구
        if (Input.GetKey(KeyCode.RightArrow))
        {
            isRight = 1;
            transform.localScale = new Vector3(0.5f, 0.5f, 1);
            transform.position += Vector3.right * Time.deltaTime * _speed;
        }
        //leftArrow 누를 때 왼쪽 이동 / sprite 반전
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            isRight = -1;
            transform.localScale = new Vector3(-0.5f, 0.5f, 1);
            transform.position += Vector3.left * Time.deltaTime * _speed;
        }
    }
}
