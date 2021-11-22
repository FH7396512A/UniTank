using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainButtonController : MonoBehaviour
{
    public GameObject LoginButton, RegisterButton, LoginPageButton, RegisterPageButton, BackButton;

    // 메인화면에서 로그인 버튼이 눌렸을 때
    public void OnLoginButtonClicked()
    {
        // Login 오브젝트를 제외한 다른 모든 오브젝트를 비활성화
        LoginButton.gameObject.SetActive(false);
        RegisterButton.gameObject.SetActive(false);
        LoginPageButton.gameObject.SetActive(true);
        BackButton.gameObject.SetActive(true);
    }

    // 메인화면에서 회원가입 버튼이 눌렸을 때
    public void OnRegisterButtonClicked()
    {
        // CreateID 오브젝트를 제외한 다른 모든 오브젝트를 비활성화
        LoginButton.gameObject.SetActive(false);
        RegisterButton.gameObject.SetActive(false);
        RegisterPageButton.gameObject.SetActive(true);
        BackButton.gameObject.SetActive(true);
    }

    public void OnBackButtonClicked()
    {
        LoginButton.gameObject.SetActive(true);
        RegisterButton.gameObject.SetActive(true);
        BackButton.gameObject.SetActive(false);
        if (LoginPageButton.gameObject.activeSelf == true)
        {
            LoginPageButton.gameObject.SetActive(false);
        }
        else if (RegisterPageButton.gameObject.activeSelf == true)
        {
            RegisterPageButton.gameObject.SetActive(false);
        }
    }
}
