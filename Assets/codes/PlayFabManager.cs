using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayFabManager : MonoBehaviour
{
    public InputField ID_Input, PW_Input, Create_ID_Input, Create_PW_Input, Create_Name_Input;

    string patternID = @"^[\w.%+\-]+@[\w.\-]+\.[A-Za-z]{2,3}$";
    string patternPW = @"^[0-9a-zA-Z!@#$%&*]{6,20}$";
    string patternName = @"^[0-9a-zA-Z]{2,8}$";

    public void Login_Button()
    {
        var request = new LoginWithEmailAddressRequest { Email = ID_Input.text, Password = PW_Input.text };
        if (Regex.IsMatch(ID_Input.text, patternID) && Regex.IsMatch(PW_Input.text, patternPW))
        {
            PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnLoginFailure);
        }
        else
        {
            Debug.LogError("로그인 실패");
            if (!Regex.IsMatch(ID_Input.text, patternID)) Debug.LogError("아이디 오류");
            if (!Regex.IsMatch(PW_Input.text, patternPW)) Debug.LogError("패스워드 오류");
        }
    }
    public void CreatID_Button()
    {
        if (Regex.IsMatch(Create_ID_Input.text, patternID) && Regex.IsMatch(Create_PW_Input.text, patternPW) && Regex.IsMatch(Create_Name_Input.text, patternName))
        {
            var request = new RegisterPlayFabUserRequest { Email = Create_ID_Input.text, Password = Create_PW_Input.text, Username = Create_Name_Input.text };
            PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnRegisterFailure);
        }
        else
        {
            Debug.LogError("회원가입 실패");
            if (!Regex.IsMatch(Create_ID_Input.text, patternID)) Debug.LogError("아이디 오류");
            if (!Regex.IsMatch(Create_PW_Input.text, patternPW)) Debug.LogError("패스워드 오류");
            if (!Regex.IsMatch(Create_Name_Input.text, patternName)) Debug.LogError("닉네임 오류");
        }
    }

    private void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        Debug.Log("회원가입 성공");
    }
    private void OnRegisterFailure(PlayFabError error)
    {
        Debug.LogError("회원가입 실패");
    }
    private void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("로그인 성공");
    }
    private void OnLoginFailure(PlayFabError error)
    {
        Debug.LogError("로그인 실패");
    }
}
