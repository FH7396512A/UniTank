using UnityEngine;
using System.Collections;

public class MainCamCtrl : MonoBehaviour
{
    public GameObject A;
    public Transform AT;

    private float ZoomMax = 10f;
    private float ZoomMin = 4f;
    public bool checkZoomOut = false;
    private float CameraSpeed = 0.5f;
    private Vector3 CameraOffset = new Vector3(0, 0, 0);
    private float WorldWidth = 37.5f;

    public bool shootstatus;

    void Start()
    {
        
        shootstatus = false;
        AT = A.transform;
    }
    void Update()
    {
        if (shootstatus == true)
        {
            transform.position = GameObject.Find("Bullet(Clone)").GetComponent<Transform>().position;
            transform.Translate(0, 0, -10);
            GetComponent<Camera>().orthographicSize = ZoomMax;
        }
        else if (shootstatus == false)
        {
            
            if (checkZoomOut == true)
            {
                transform.position = AT.position + CameraOffset;
                transform.Translate(0, 0, -10);
                if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > 5f) CameraOffset.x -= CameraSpeed;
                if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < WorldWidth) CameraOffset.x += CameraSpeed;
            }
            else
            {
                CameraOffset.x = 0f;
                transform.position = Vector3.Lerp(transform.position, AT.position + CameraOffset, 2f * Time.deltaTime);
                transform.Translate(0, 0, -10);
            }
        }

        CameraZoom();
    }

    void CameraZoom()
    {
        if (Input.GetKeyDown(KeyCode.C) == true)
        {
            if (checkZoomOut == false)
            {
                GetComponent<Camera>().orthographicSize = ZoomMax;
                checkZoomOut = true;
            }
            else if (checkZoomOut == true)
            {
                GetComponent<Camera>().orthographicSize = ZoomMin;
                checkZoomOut = false;
            }
        }
    }
}