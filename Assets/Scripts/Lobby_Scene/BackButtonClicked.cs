using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButtonClicked : MonoBehaviour
{
    public void BackButtonOnClicked()
    {
        Debug.Log("Back to Main");
        SceneManager.LoadScene("Main");
    }
}
