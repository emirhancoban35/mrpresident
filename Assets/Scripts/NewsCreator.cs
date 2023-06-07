using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;

public class NewsCreator : MonoBehaviour
{
    public List<News> newsList = new List<News>();
    public GameObject newsPrefab;
    private RectTransform _createdTransform;
    private GameObject _panel;
    public List<GameObject> newsPrefabs = new List<GameObject>();

    private void Start()
    {
        _panel = GameObject.FindWithTag("Panel");
    }

    public void CreateNews()
    {

        int randomNewsNumber = Random.Range(0, newsList.Count);
        News createdNews = newsList[randomNewsNumber];
        
        GameObject instantiatedPrefab = Instantiate(newsPrefab , _panel.transform);
    
        foreach (var news in newsPrefabs)   
        {
            var newsTransform = news.GetComponent<RectTransform>();
            
        }
        newsPrefabs.Add(instantiatedPrefab);
        
        instantiatedPrefab.transform.parent = _panel.transform;

        Text textComponent = instantiatedPrefab.GetComponentInChildren<Text>();

        textComponent.text = createdNews.newsText;  
        
        newsList.RemoveAt(randomNewsNumber);
    }
}