using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    public Vector3 _direction;
    public GameObject Boom;
    private float moveSpeed = 20.0f;
    private float _G = 0.005f;
    private Vector3 _Pos;
    private Vector3 _ST;
    private Vector3 _Gravity = new Vector3(0, 0, 0);
    void Start()
    {
        _Pos = _direction;
        _ST = transform.position;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        Instantiate(Boom, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

    void Update()
    {
        _ST = _ST + _Pos * Time.deltaTime * moveSpeed - _Gravity;
        transform.position = _ST;
        _Gravity.y += _G;
    }
}
