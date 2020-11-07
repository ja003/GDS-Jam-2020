using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] Button btnStart;
    [SerializeField] Button btnSettings;
    [SerializeField] Button btnAbout;
    [SerializeField] Button btnExit;


    [SerializeField] MenuMap map;


    private void Awake()
    {
        btnStart.onClick.AddListener(OnBtnStart);
    }

    private void OnBtnStart()
    {
        gameObject.SetActive(false);
        map.gameObject.SetActive(true);
    }
}
