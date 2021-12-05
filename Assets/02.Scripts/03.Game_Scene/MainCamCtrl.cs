using UnityEngine;
using System.Collections;

public class MainCamCtrl : MonoBehaviour
{
    public GameObject A;
    Transform AT;
    [SerializeField] float ZoomSpeed = 0f; //줌속도
    [SerializeField] float ZoomMax = 0f; //최대줌(가깝게)
    [SerializeField] float ZoomMin = 0f; //최소줌(멀게)

    void Start()
    {
        AT = A.transform;
    }
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, AT.position, 2f * Time.deltaTime);
        transform.Translate(0, 0, -10);

        CameraZoom();

    }

    void CameraZoom()
    {
        float ZoomDir = Input.GetAxis("Mouse ScrollWheel");

        if (GetComponent<Camera>().orthographicSize <= ZoomMax && ZoomDir > 0)                 
            return;       
        if (GetComponent<Camera>().orthographicSize >= ZoomMin && ZoomDir < 0)                   
            return;
                    
        GetComponent<Camera>().orthographicSize += ZoomDir * -ZoomSpeed;
    }
}