using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    [SerializeField] Button button;
    [SerializeField] Image background;
    [SerializeField] Text text;

    [SerializeField] Sprite btnEnabled;
    [SerializeField] Sprite btnDisabled;

    [SerializeField] Color textColorEnabled;
    [SerializeField] Color textColorDisabled;

    public void SetEnabled(bool pEnabled)
    {
        button.interactable = pEnabled;
        button.image.sprite = pEnabled ? btnEnabled : btnDisabled;

        text.color = pEnabled ? textColorEnabled : textColorDisabled;
    }

    internal void AddAction(Action OnCLick)
    {
        button.onClick.AddListener(OnCLick.Invoke);
    }
}
