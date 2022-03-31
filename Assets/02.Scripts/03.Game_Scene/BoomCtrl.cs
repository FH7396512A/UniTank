using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class BoomCtrl : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
