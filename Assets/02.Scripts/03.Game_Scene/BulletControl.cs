using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletControl : MonoBehaviour
{
    public Vector3 _direction;
    public GameObject Boom;
    public Collider2D Tank;
    private float moveSpeed = 20.0f;
    private float _G = 0.005f;
    private Vector3 _Pos;
    private Vector3 _ST;
    private Vector3 _Gravity = new Vector3(0, 0, 0);

    
    //public float timer = 0f;
    
    void Start()
    {
        //timer = 0f;
        Tank = GameObject.Find("Tank").GetComponent<Collider2D>();
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
        /*
        RaycastHit2D hits;
        hits = Physics2D.Raycast(transform.position, Vector3.down);       
        Debug.DrawRay(transform.position, Vector3.down * 5, Color.red);

        //timer += 1 * Time.deltaTime;

        
        if (hits == null) return;       
        else
        {
            if (hits.distance < 100)
            {
                if (hits.collider == Tank) return;
                else
                {
                    Instantiate(Boom, this.transform.position, Quaternion.identity);
                    Destroy(this.gameObject);
                    Debug.Log(hits.distance, hits.collider);
                }
            }
        }    
        */


        _ST = _ST + _Pos * Time.deltaTime * moveSpeed - _Gravity;
        transform.position = _ST;
        _Gravity.y += _G;
        
    }


}
