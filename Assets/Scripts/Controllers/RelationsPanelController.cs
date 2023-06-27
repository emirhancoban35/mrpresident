using System.Collections;
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

    public void CreateNewPanel(int relationshipLevel,Sprite countryFlag,string countryName)
    {
        // Debug.Log(" ");
        _relationsPanel.gameObject.SetActive(true);
        GameObject instantiatedPrefab = Instantiate(relationsPrefab, GetPanelLocation());
        instantiatedPrefab.transform.SetParent(GetPanelLocation(), false);
        
        Text textComponent = relationsPrefab.GetComponentInChildren<Text>();
        Image image = relationsPrefab.GetComponentInChildren<Image>();
        Slider slider = relationsPrefab.GetComponentInChildren<Slider>();
        image.sprite = countryFlag;
        textComponent.text = countryName;
        slider.value = relationshipLevel;
    }
}
