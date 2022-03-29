using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPrefabCon : MonoBehaviour
{
    public GameObject Tank;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Tank);
        GameObject.Find("Main Camera").GetComponent<MainCamCtrl>().A = GameObject.Find("CameraPos");
        GameObject.Find("Main Camera").GetComponent<MainCamCtrl>().AT = GameObject.Find("Main Camera").GetComponent<MainCamCtrl>().A.transform;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(Tank.GetComponent<PlayerControl>().HPBar_I.value <= 0)
        {
            Destroy(Tank);
        }
        */
    }
}
