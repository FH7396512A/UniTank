using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class TankPrefabCon : MonoBehaviourPunCallbacks
{
    public GameObject Tank;

    // Start is called before the first frame update
    void Start()
    {

        CreateTank(Tank);
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
    #region 탱크 생성 //
    void CreateTank(GameObject Tank)
    {
        Transform[] points = GameObject.Find("SpawnPointGroup").GetComponentsInChildren<Transform>();
        int idx = Random.Range(1, points.Length);
        Instantiate(Tank);
        //PhotonNetwork.Instantiate("Tank", points[idx].position, Quaternion.identity);
    }
    #endregion
}
