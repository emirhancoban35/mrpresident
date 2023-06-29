using System.Collections.Generic;
using Interfaces;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class RelationsPanelController : MonoBehaviour
{
    public GameObject relationsPrefab;
    
    [Inject(Id = "ReloatinshipPanel")]
    private RectTransform _relationsPanel;

    private float _panelSpacing = 10f; // İlişki panelleri arasındaki boşluk miktarı

    private void Start()
    {
        _relationsPanel = GameObject.Find("NewsPanel").GetComponent<RectTransform>();
    }

    public RectTransform GetPanelLocation()
    {
        return _relationsPanel;
    }

    public void SetPanelSize()
    {
        
    } 

    public void CreateNewPanel(int relationshipLevel, Sprite countryFlag, string countryName)
    {
        _relationsPanel.gameObject.SetActive(true);

        GameObject instantiatedPrefab = Instantiate(relationsPrefab, GetPanelLocation());
        instantiatedPrefab.transform.SetParent(GetPanelLocation(), false);
        
        Text textComponent = instantiatedPrefab.GetComponentInChildren<Text>();
        Image image = instantiatedPrefab.GetComponentInChildren<Image>();
        Slider slider = instantiatedPrefab.GetComponentInChildren<Slider>();
        image.sprite = countryFlag;
        textComponent.text = countryName;
        slider.value = relationshipLevel;

        // İlişki panellerini alt alta hizalamak için panelin pozisyonunu güncelle
        Vector2 panelPosition = _relationsPanel.anchoredPosition;
        panelPosition.y -= (_panelSpacing + GetPanelHeight(instantiatedPrefab));
        _relationsPanel.anchoredPosition = panelPosition;
    }

    private float GetPanelHeight(GameObject panelObject)
    {
        RectTransform panelTransform = panelObject.GetComponent<RectTransform>();
        return panelTransform.rect.height;
    }
}