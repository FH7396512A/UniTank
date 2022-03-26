using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UI : MonoBehaviour
{
    public GameObject SettingPanel, OnImg1, OffImg1, YouLose;

    public bool SkillDSON = false;
    public TMP_Text SkillDSIndicate;
    public int SkillDSCounter;

    // Start is called before the first frame update
    void Start()
    {
        SettingPanel.gameObject.SetActive(false);
        OffImg1.gameObject.SetActive(true);
        OnImg1.gameObject.SetActive(false);
        YouLose.gameObject.SetActive(false);
        SkillDSON = false;
        SkillDSCounter = 3;
        SkillDSIndicate.text = SkillDSCounter.ToString();
}

    // Update is called once per frame
    void Update()
    {
        SkillDSIndicate.text = SkillDSCounter.ToString();
        if (Input.GetKeyDown(KeyCode.Escape) == true)
        {
            OnSettingButtonClicked();
        }
        if (/*hp >= 0 ||*/ GameObject.Find("Tank(Clone)").GetComponent<Transform>().position.y < -15f)
        {
            YouLose.gameObject.SetActive(true);
        }
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
    public void BackToLobbyButtonClicked()
    {
        SceneManager.LoadScene("Lobby");
        Debug.Log("BackToMenu Clicked!");
    }
    public void SkillDoubleShotTriggered()
    {
        Debug.Log(SkillDSCounter);
        if (SkillDSCounter <= 0)
        {
            SkillDSON = false;
            OffImg1.gameObject.SetActive(true);
            OnImg1.gameObject.SetActive(false);
            SkillDSCounter = 0;
        }
        else
        {           
            if (SkillDSON == false)
            {
                SkillDSON = true;
                OffImg1.gameObject.SetActive(false);
                OnImg1.gameObject.SetActive(true);
            }
            else if (SkillDSON == true)
            {
                SkillDSON = false;
                OffImg1.gameObject.SetActive(true);
                OnImg1.gameObject.SetActive(false);
            }
        }
    }
    
}
