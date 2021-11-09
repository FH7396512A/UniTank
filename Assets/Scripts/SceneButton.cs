using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneButton : MonoBehaviour
{
    public void SceneChange()
    {
        //임시로 만들어놓은 테스트코드
        SceneManager.LoadScene("SelectMenu");
    }
}
