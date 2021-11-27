using UnityEngine;
using System.Collections;

public class MainCamCtrl : MonoBehaviour
{
    public GameObject A;
    Transform AT;
    void Start()
    {
        AT = A.transform;
    }
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, AT.position, 2f * Time.deltaTime);
        transform.Translate(0, 0, -10);
    }
}