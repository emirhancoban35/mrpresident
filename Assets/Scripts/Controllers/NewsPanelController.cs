using Interfaces;
using UnityEngine;
using Zenject;

public class NewsPanelController : MonoSingleton<NewsPanelController>, IPanelController
{
    private RectTransform _newsPanel;
    private RectTransform _panel;
    private Transform _newsPanelTransform;

    [Inject]
    public void Initialize([Inject(Id = "NewsPanel")] RectTransform newsPanel, [Inject(Id = "Panel")] RectTransform panel)
    {
        _newsPanel = newsPanel;
        _panel = panel;
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