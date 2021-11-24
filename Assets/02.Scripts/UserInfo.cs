using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInfo : MonoBehaviour
{
    public static string _DisplayName, _PlayFabID;
    public string GetDisplayName()
    {
        return _DisplayName;
    }
}
