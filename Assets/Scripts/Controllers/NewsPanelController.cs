using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewsPanelController : MonoSingleton<NewsPanelController>
{
    private RectTransform _newsPanel;
    private RectTransform _panel;
    private Transform _newsPanelTransform;

    private void Start()
    {
        _newsPanel = GameObject.Find("NewsPanel").GetComponent<RectTransform>();
        _panel = GameObject.Find("Panel").GetComponent<RectTransform>();
        _newsPanelTransform = _newsPanel.transform;
    }

    public Transform GetPanelLocation()
    {
        return _newsPanelTransform;
    }
    
    public Transform GetNewsPanelLocation()
    {
        return _panel.transform;
    }

    public void SetSizePanel()
    {
        var currentScale = _newsPanel.localScale;
        var currentPositionY = _newsPanel.anchoredPosition.y;
        currentScale.y += 0.1f;
        float newYPosition = currentPositionY + 57f;
        _newsPanel.anchoredPosition = new Vector2(_newsPanel.anchoredPosition.x, newYPosition);
        _newsPanel.localScale = currentScale;
    }
}
