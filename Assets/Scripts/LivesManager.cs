using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class LivesManager : MonoBehaviour
{
    public static LivesManager instance;
    private GameObject[] livesImageUI;
    private GameObject panelLives;
    private Color uiImageColor;

    private int liveCounter = 5;

    private void Awake()
    {
        instance = this;
        uiImageColor = new Color(1, 1, 1, 0.3f);
    }

    private void Start()
    {
        panelLives = GameObject.Find("PanelLives");
        livesImageUI = new GameObject[panelLives.transform.childCount];

        for (int i = 0; i < livesImageUI.Length; i++)
            livesImageUI[i] = GameObject.Find($"Live{i + 1}");
    }

    public void RemoveLife()
    {
        if (liveCounter > 0)
        {
            liveCounter--;
            SetLiveImageUI();
        }
        if (liveCounter <= 0)
            GameController.instance.GameOver();
    }

    private void SetLiveImageUI()
    {
        livesImageUI[liveCounter].GetComponent<Image>().color = uiImageColor;
    }
}
