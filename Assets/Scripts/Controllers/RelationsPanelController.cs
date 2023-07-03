using System.Collections.Generic;
using Interfaces;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class RelationsPanelController : MonoBehaviour
{
    public GameObject relationsPrefab;
    public Transform panelContent; // İlişki panellerinin yerleştirileceği içerik paneli

    private float panelSpacing = 500f; // İlişki panelleri arasındaki boşluk miktarı
    private float panelHeight; // İlişki panelinin yüksekliği

    private void Start()
    {
        panelContent = GameObject.Find("RelationshipPanel/Content").transform;
        panelHeight = relationsPrefab.GetComponent<RectTransform>().rect.height;
    }

    public void CreateNewPanel(int relationshipLevel, Sprite countryFlag, string countryName)
    {
        GameObject instantiatedPrefab = Instantiate(relationsPrefab, panelContent);
        RectTransform panelTransform = instantiatedPrefab.GetComponent<RectTransform>();
        panelTransform.anchoredPosition = new Vector2(0f, CalculatePanelPositionY());

        Text textComponent = instantiatedPrefab.GetComponentInChildren<Text>();
        Image image = instantiatedPrefab.GetComponentInChildren<Image>();
        Slider slider = instantiatedPrefab.GetComponentInChildren<Slider>();
        image.sprite = countryFlag;
        textComponent.text = countryName;
        slider.value = relationshipLevel;
    }

    private float CalculatePanelPositionY()
    {
        int panelCount = panelContent.childCount;
        float totalHeight = panelHeight * panelCount + panelSpacing * (panelCount - 1);
        return -totalHeight + panelHeight * 0.5f;
    }
}