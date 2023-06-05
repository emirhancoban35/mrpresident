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
        
    }
}
