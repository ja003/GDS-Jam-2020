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

	[SerializeField] Button btnBack;


	[SerializeField] MenuMap map;
	[SerializeField] MenuSettings settings;
	[SerializeField] GameObject about;


	private void Awake()
    {
		btnBack.onClick.AddListener(OnBtnBack);
		btnBack.gameObject.SetActive(false);

		btnStart.onClick.AddListener(OnBtnStart);
		btnSettings.onClick.AddListener(OnBtnSettings);
		btnAbout.onClick.AddListener(OnBtnAbout);
		btnExit.onClick.AddListener(OnBtnExit);
	}

	private void OnBtnBack()
	{
		btnBack.gameObject.SetActive(false);

		map.gameObject.SetActive(false);
		settings.gameObject.SetActive(false);
		about.gameObject.SetActive(false);

		gameObject.SetActive(true);
	}

	private void OnBtnStart()
	{
		gameObject.SetActive(false);
		map.gameObject.SetActive(true);
		btnBack.gameObject.SetActive(true);
	}

	private void OnBtnSettings()
	{
		gameObject.SetActive(false);
		settings.gameObject.SetActive(true);
		btnBack.gameObject.SetActive(true);
	}

	private void OnBtnAbout()
	{
		gameObject.SetActive(false);
		about.gameObject.SetActive(true);
		btnBack.gameObject.SetActive(true);
	}

	private void OnBtnExit()
	{
		Application.Quit();
	}

}
