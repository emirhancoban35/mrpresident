using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewsPanelController : MonoSingleton<NewsPanelController>
{
    private RectTransform _newsPanel;
    private void Start()
    {
        _newsPanel = GameObject.Find("NewsPanel").GetComponent<RectTransform>();
    }

    public void NewNews()
    {
        var currentPosition = _newsPanel.localPosition;
        var currentScale = _newsPanel.localScale;
        var currentLocation = _newsPanel.localRotation;
        currentPosition.y += 5f;
        currentPosition.y += 10f;
        currentLocation.y -= 5f;
        _newsPanel.localPosition= currentPosition;
        _newsPanel.localScale = currentScale;
    }
}
