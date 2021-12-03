using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOnlyOne : MonoBehaviour
{
    static SoundOnlyOne s_instance;
    
    public GameObject SoundPrefab;

    void Start()
    {
        Init();
    }

    void Init()
    {              
        if (GameObject.Find("MusicCanvas(Clone)") == null)
        {
            Instantiate(SoundPrefab);
        }                 
    }
}
