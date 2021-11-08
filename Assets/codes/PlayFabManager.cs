using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;

public class PlayFabManager : MonoBehaviour
{
    public InputField ID_Input, PW_Input, Name_Input;
    public void Login_Button()
    {
        var request = new LoginWithEmailAddressRequest { Email = ID_Input.text, Password = PW_Input.text };
        PlayFabClientAPI.LoginWithEmailAddress(request, (result) => Debug.Log("로그인 성공"), OnLoginFailure);
    }
    public void CreatID_Button()
    {
        var request = new RegisterPlayFabUserRequest { Email = ID_Input.text, Password = PW_Input.text, Username = Name_Input.text };
        PlayFabClientAPI.RegisterPlayFabUser(request, (result) => Debug.Log("회원가입 성공"), OnRegisterFailure);
    }

    private void OnRegisterFailure(PlayFabError error)
    {
        Debug.LogError("회원가입 실패");
        Debug.LogError(error.GenerateErrorReport());
    }
    private void OnLoginFailure(PlayFabError error)
    {
        Debug.LogError("로그인 실패");
        Debug.LogError(error.GenerateErrorReport());
    }
}
