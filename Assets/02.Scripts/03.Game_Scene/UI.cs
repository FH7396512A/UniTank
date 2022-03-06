using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public GameObject SettingPanel;

    // Start is called before the first frame update
    void Start()
    {
        SettingPanel.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSettingButtonClicked()
    {
        if (SettingPanel.gameObject.activeSelf == true) SettingPanel.gameObject.SetActive(false);
        else if (SettingPanel.gameObject.activeSelf == false) SettingPanel.gameObject.SetActive(true);
    }

    public void QuitButtonClicked()
    {
        Application.Quit();
        Debug.Log("GameQuit Clicked!");
    }
}
