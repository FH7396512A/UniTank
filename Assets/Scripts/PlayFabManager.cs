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
    public string _PlayFabID, _DisplayName = null;
    public InputField ID_Input, PW_Input, Create_ID_Input, Create_PW_Input, Create_Name_Input, Create_NN_Input;

    string patternID = @"^[\w.%+\-]+@[\w.\-]+\.[A-Za-z]{2,3}$";//이메일 형식
    string patternPW = @"^[0-9a-zA-Z!@#$%&*]{6,20}$";//패스워드 영어 숫자 특수문자로 구성 6-20자
    string patternName = @"^[0-9a-zA-Z]{2,20}$";//이름 영어 숫자로 구성 2-20자
    string patternNN = @"^[0-9a-zA-Z가-힣]{3,8}$";//닉네임 숫자 영어 한글 영어로 구성 3-8자

    //버튼입력 로그인
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

    //버튼입력 회원가입
    public void CreatID_Button()
    {
        if (Regex.IsMatch(Create_ID_Input.text, patternID) && Regex.IsMatch(Create_PW_Input.text, patternPW) &&
            Regex.IsMatch(Create_Name_Input.text, patternName) && Regex.IsMatch(Create_NN_Input.text, patternNN))
        {
            var request = new RegisterPlayFabUserRequest { Email = Create_ID_Input.text, Password = Create_PW_Input.text, Username = Create_Name_Input.text };
            PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnRegisterFailure);
        }
        else
        {
            Debug.LogError("회원가입 실패");
            if (!Regex.IsMatch(Create_ID_Input.text, patternID)) Debug.LogError("아이디 오류");
            if (!Regex.IsMatch(Create_PW_Input.text, patternPW)) Debug.LogError("패스워드 오류");
            if (!Regex.IsMatch(Create_Name_Input.text, patternName)) Debug.LogError("이름 오류");
            if (!Regex.IsMatch(Create_NN_Input.text, patternNN)) Debug.LogError("닉네임 오류");
        }
    }

    void UpdateDisplayName()
    {
        PlayFabClientAPI.UpdateUserTitleDisplayName(new UpdateUserTitleDisplayNameRequest
        {
            DisplayName = Create_NN_Input.text
        }, result => {
            Debug.Log("The player's display name is now: " + result.DisplayName);
        }, error => Debug.LogError(error.GenerateErrorReport()));
    }

    private void GetPlayerProfile(string playFabId)
    {
        PlayFabClientAPI.GetPlayerProfile(new GetPlayerProfileRequest()
        {
            PlayFabId = playFabId,
            ProfileConstraints = new PlayerProfileViewConstraints()
            {
                ShowDisplayName = true
            }
        },
        result => {
            Debug.Log("The player's DisplayName profile data is: " + result.PlayerProfile.DisplayName);
            _DisplayName = result.PlayerProfile.DisplayName;
            GameObject.Find("UserInfo").GetComponent<UserInfo>()._DisplayName = _DisplayName;
            ///
            SceneManager.LoadScene("Lobby");
        }, error => Debug.LogError(error.GenerateErrorReport()));
    }

    public void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        Debug.Log("회원가입 성공");
        UpdateDisplayName();
    }
    private void OnRegisterFailure(PlayFabError error)
    {
        Debug.LogError("회원가입 실패");
    }

    private void OnLoginSuccess(LoginResult result)
    {
        PlayFabClientAPI.GetAccountInfo(new GetAccountInfoRequest { Email = ID_Input.text },
            results => {
                //Handle AccountInfo
                Debug.Log(results.AccountInfo.PlayFabId);
                _PlayFabID = results.AccountInfo.PlayFabId;
                GameObject.Find("UserInfo").GetComponent<UserInfo>()._PlayFabID = _PlayFabID;
            }, errors => { Debug.LogError(errors.GenerateErrorReport()); });
        Debug.Log("로그인 성공");
        GetPlayerProfile(_PlayFabID);
    }

    private void OnLoginFailure(PlayFabError error)
    {
        Debug.LogError("로그인 실패");
    }
}



