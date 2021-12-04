using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    public float moveSpeed = 30.0f;
    public int _isRight;
    public Vector3 _direction;
    private Vector3 _dir;
    public GameObject Boom;
    void Start()
    {
        _dir = _direction;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        Instantiate(Boom, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

    void Update()
    {
        transform.Translate(_dir * Time.deltaTime * moveSpeed);
    }
}
