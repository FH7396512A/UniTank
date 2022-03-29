using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInfo : MonoBehaviour
{
    public static string _DisplayName = "UnKnown", _PlayFabID;
    public string GetDisplayName()
    {
        return _DisplayName;
    }
}
