using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    public float moveSpeed = 30.0f;
    public int _isRight;
    public Vector3 _direction;
    public GameObject Boom;
    void Start()
    {
        
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Tank")
        {
            Instantiate(Boom, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        if (coll.gameObject.tag == "Ground")
        {
            Instantiate(Boom, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    void Update()
    {
        transform.Translate(_direction * Time.deltaTime * moveSpeed);
    }
}
