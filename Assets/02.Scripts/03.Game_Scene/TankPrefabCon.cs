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
