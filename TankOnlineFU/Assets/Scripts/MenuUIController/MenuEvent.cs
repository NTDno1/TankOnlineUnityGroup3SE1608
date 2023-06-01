using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class MenuEvent : MonoBehaviour
{
    public GameObject gameoverPanel;
    public GameObject pausePanel;
    public Button playPanel;
    public Button exitPanel;
    public void Play()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Contruction()
    {
        SceneManager.LoadScene("ContructionSence");
    }

    public void ReStartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Character");
    }

    public void ShowGameoverPanel(bool isShow)
    {
        gameoverPanel.SetActive(isShow);
    }

    public void ReplayPanel()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    public void PlayPanel()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    public void ExitPanel(int index)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("menuUI");
    }
}
