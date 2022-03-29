using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletControl : MonoBehaviour
{
    public Vector3 _direction;
    public GameObject Boom;
    public Collider2D Tank;

    [SerializeField]
    private float moveSpeed = 8.0f; //20.0f
    private float _G = 0.0025f; //0.005f
    
    private Vector3 _Pos;
    public Vector3 _ST;
    private Vector3 _Gravity = new Vector3(0, 0, 0);

    
    //public float timer = 0f;
    
    void Start()
    {
        //timer = 0f;
        Tank = GameObject.Find("Tank(Clone)").GetComponent<Collider2D>();
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
        //_ST = _ST + _Pos * Time.deltaTime * moveSpeed - _Gravity;
        //transform.position = Vector3.Slerp(this.transform.position, _ST, 0.5f);

        _ST = _ST + _Pos * Time.deltaTime * moveSpeed - _Gravity;
        transform.position = _ST;
        _Gravity.y += _G;
        
    }   
}
